using System;
using UnityEngine;

namespace Player
{
    public class AnimationController
    {
        private Animator _animator;
        private int VelocityZ => Animator.StringToHash("v");
        private int VelocityY=> Animator.StringToHash("vy");
        public AnimationController(Animator animator)
        {
            _animator = animator;
        }

        public void DisableAnimator()
        {
            _animator.enabled = false;
        }

        public void SetVelocityZ(float velocity)
        {
            _animator.SetFloat(VelocityZ,velocity);
        }

        public void TriggerJump()
        {
            _animator.SetTrigger("jump");
        }
        
        public void SetVelocityY(float velocity)
        {
            _animator.SetFloat(VelocityY,velocity);
        }

        public void Falling(bool isFalling)
        {
            _animator.SetBool("falling",isFalling);
        }
        
        public void SetGrounded(bool isGrounded)
        {
            _animator.SetBool("grounded",isGrounded);
        }
        
        public void SetSlide(bool isSlide)
        {
            _animator.SetBool("slide",isSlide);
        }
        
    }
}