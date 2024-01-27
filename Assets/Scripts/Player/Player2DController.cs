using System;
using UnityEngine;

namespace Player
{
    public class Player2DController : MonoBehaviour
    {
        [SerializeField] private float playerMoveSpeed;
        
        private InputScheme _inputScheme;
        private Mover2D _mover;
        private void Awake()
        {
            _inputScheme = new InputScheme(); 
            _mover = new Mover2D(transform);
            _mover.SetVariables(playerMoveSpeed,7.5f);
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
            _mover.Move(new Vector2(_inputScheme.Player.HorizontalAxis.ReadValue<float>(),0f));
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -6.5f, 6.5f);
            transform.position = clampedPosition;
        }
    }
}