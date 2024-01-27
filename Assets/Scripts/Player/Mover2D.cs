using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Mover2D : MonoBehaviour
    {
        private Transform _transform;
        private float _horizontalMoveSpeed;
        private float _verticalMoveSpeed;
        private Vector3 _movement;

        public Mover2D(Transform transform)
        {
            _transform = transform;
        }
        private void Awake()
        {
            _transform = transform;
        }
        
        public void SetVariables(float horizontal, float vertical)
        {
            _horizontalMoveSpeed = horizontal;
            _verticalMoveSpeed = vertical;
        }
        
        public void Move(Vector2 direction)
        {
            _movement = new Vector3(direction.x,direction.y,0f);
            _transform.position += _movement * _horizontalMoveSpeed * Time.fixedDeltaTime;
        }
        
    }
}