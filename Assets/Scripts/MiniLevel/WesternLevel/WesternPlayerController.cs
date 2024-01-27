using Player;
using UnityEngine;

namespace MiniLevel.WesternLevel
{
    public class WesternPlayerController : MonoBehaviour
    {
        [SerializeField] private float playerMoveSpeed;
        
        private InputScheme _inputScheme;
        private Mover2D _mover;
        private void Awake()
        {
            _inputScheme = new InputScheme(); 
            _mover = new Mover2D(transform);
            _mover.SetVariables(playerMoveSpeed,playerMoveSpeed);
        }
        
        private void OnEnable()
        {
            _inputScheme.Player.Enable();
        }
        
        private void OnDisable()
        {
            _inputScheme.Player.Disable();
        }

        private void FixedUpdate()
        {
            _mover.Move(new Vector2(0f,_inputScheme.Player.VeritcalAxis.ReadValue<float>()));
            Vector3 clampedPosition = transform.position;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -2.5f, 5f);
            transform.position = clampedPosition;
        }    
    }
}