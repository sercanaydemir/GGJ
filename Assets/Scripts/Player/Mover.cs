using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    [System.Serializable]
    public class Mover
    {
        private Transform _transform;
        private float speed = 5f;
        private Transform groundCheckPosition;
        private float groundCheckRadius = 0.1f;
        public float jumpPower;
        public LayerMask groundLayer;
        private bool isJump;
        
        private float jumpTime = 0.25f;

        public float appliedJumpPower = 0;
        public Mover(Transform transform)
        {
            _transform = transform;
        }
        
        public void SetVariables(float jumpPower,float speed,Transform groundCheckPosition,float groundCheckRadius,LayerMask groundLayer)
        {
            this.speed = speed;
            this.groundCheckPosition = groundCheckPosition;
            this.groundCheckRadius = groundCheckRadius;
            this.jumpPower = jumpPower;
            this.groundLayer = groundLayer;
        }
        
        public void Move(Vector3 direction,float gravity)
        {
            Rotate(direction);
            Vector3 moveDirection = new Vector3(0,appliedJumpPower,direction.z)*speed;

            if (!CheckGrounded())
            {
                appliedJumpPower-=gravity*Time.fixedDeltaTime;
                if (appliedJumpPower < 0)
                    appliedJumpPower = 0;
            }
            
            _transform.position += moveDirection * Time.fixedDeltaTime;
            
        }
        
        public void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero) return;
            if(_transform.forward.z/direction.z < 0)
                _transform.Rotate(Vector3.up,180f);
        }

        public void Jump()
        {
            if(!CheckGrounded()) return;
            Debug.LogError("Jump");
            isJump = !isJump;
            appliedJumpPower = jumpPower;
        }
        
        public bool CheckGrounded()
        {
            return Physics.CheckSphere(groundCheckPosition.position, groundCheckRadius, groundLayer);
        }
        
        public void OnDrawGizmos()
        {
            if(groundCheckPosition == null) return; 
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckPosition.position,groundCheckRadius);
        }
    }
}