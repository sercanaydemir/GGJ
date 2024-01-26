using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        [SerializeField] private Transform groundCheckPosition;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private LayerMask groundLayer;
        
        private Mover mover;
        private InputScheme inputScheme;
        private AnimationController _animationController;
        private Vector3 MovementVector => new Vector3(0, 0, inputScheme.Player.HorizontalAxis.ReadValue<float>());
        
        private void Awake()
        {
            mover = new Mover(transform);
            mover.SetVariables(jumpPower,speed,groundCheckPosition,groundCheckRadius,groundLayer);
            inputScheme = new InputScheme();
            _animationController = new AnimationController(GetComponentInChildren<Animator>());
        }
        private void FixedUpdate()
        {
            Debug.LogError(MovementVector);
            mover.Move(MovementVector,5f);
        }

        private void LateUpdate()
        {
            _animationController.SetVelocityZ(Mathf.Abs(MovementVector.z));
        }

        private void JumpOnperformed(InputAction.CallbackContext obj)
        {
            mover.Jump();
        }

        private void OnEnable()
        {
            inputScheme.Player.Enable();
            inputScheme.Player.Jump.performed += JumpOnperformed;
            //inputScheme.Player.Jump.canceled += JumpOnperformed;
        }
        private void OnDisable()
        {
            inputScheme.Player.Disable();
            inputScheme.Player.Jump.performed -= JumpOnperformed;
            //inputScheme.Player.Jump.canceled -= JumpOnperformed;

        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if(mover == null) return;
            
            mover.OnDrawGizmos();
        }
#endif
    }
}