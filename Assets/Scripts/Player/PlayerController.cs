using System;
using Enemies;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        [SerializeField] private Transform groundCheckPosition;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private LayerMask groundLayer;

        [SerializeField] private GameObject mainCollider;
        [SerializeField] private GameObject slideCollider;
        
        private Mover mover;
        private InputScheme inputScheme;
        private AnimationController _animationController;
        RagdollController ragdollController;
        private Vector3 MovementVector => new Vector3(0, 0, inputScheme.Player.HorizontalAxis.ReadValue<float>());
        private Rigidbody _rigidbody;
        private bool slideStatus;
        private void Awake()
        {
            mover = new Mover(transform);
            mover.SetVariables(jumpPower,speed,groundCheckPosition,groundCheckRadius,groundLayer);
            _rigidbody = GetComponent<Rigidbody>();
            inputScheme = new InputScheme();
            _animationController = new AnimationController(GetComponentInChildren<Animator>());
            ragdollController = GetComponentInChildren<RagdollController>();
        }
        private void FixedUpdate()
        {
            mover.Move(MovementVector,5f);
        }

        private void LateUpdate()
        {
            _animationController.SetVelocityZ(Mathf.Abs(MovementVector.z));
            _animationController.SetVelocityY(_rigidbody.velocity.y);
            _animationController.SetGrounded(mover.CheckGrounded());
        }

        private void JumpOnperformed(InputAction.CallbackContext obj)
        {
            _animationController.TriggerJump();
            mover.Jump();
        }
        private void OnSlideStatusChanged(bool obj)
        {
            slideStatus = obj;
            mainCollider.SetActive(!obj);
            slideCollider.SetActive(obj);
            _animationController.SetSlide(obj);
        }

        private void CrouchOnperformed(InputAction.CallbackContext obj)
        {
            mover.Slide();
        }

        private void DieWithCollideImpact(Vector2 obj)
        {
            inputScheme.Player.Disable();
            Vector3 direction = new Vector3(obj.x,1,obj.y) - transform.position; 
            _rigidbody.AddForce(direction.normalized*5,ForceMode.Impulse);
            ragdollController.InvokeEnableRagdoll();
            _animationController.DisableAnimator();

            Invoke(nameof(InvokeScene),3);
        }

        void InvokeScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnTriggerEnter(Collider other)
        {
            // Debug.LogError("collide",other.gameObject);
            // Debug.Break();            
            
            if (other.TryGetComponent(out WesternEnemyController enemy) && slideStatus)
            {
                Debug.LogError("collide with enemy");
                enemy.Die(transform.position);
            }
        }

        private void OnEnable()
        {
            inputScheme.Player.Enable();
            inputScheme.Player.Jump.performed += JumpOnperformed;
            inputScheme.Player.Crouch.performed += CrouchOnperformed;
            mover.OnSlideStatusChanged += OnSlideStatusChanged;
            OnDieWithCollideImpact += DieWithCollideImpact;
        }


        private void OnDisable()
        {
            inputScheme.Player.Disable();
            inputScheme.Player.Jump.performed -= JumpOnperformed;
            inputScheme.Player.Crouch.performed -= CrouchOnperformed;
            mover.OnSlideStatusChanged -= OnSlideStatusChanged;
            OnDieWithCollideImpact -= DieWithCollideImpact;
        }

        #region events

        public static event Action<Vector2> OnDieWithCollideImpact;
        
        public static void InvokeDieWithCollideImpact(Vector2 impact)
        {
            OnDieWithCollideImpact?.Invoke(impact);
        }
        

        #endregion

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if(mover == null) return;
            
            mover.OnDrawGizmos();
        }
#endif
    }
}