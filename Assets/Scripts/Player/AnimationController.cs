using UnityEngine;

namespace Player
{
    public class AnimationController
    {
        private Animator _animator;
        private int VelocityZ => Animator.StringToHash("v");
        public AnimationController(Animator animator)
        {
            _animator = animator;
        }
        
        public void SetVelocityZ(float velocity)
        {
            _animator.SetFloat(VelocityZ,velocity);
        }
    }
}