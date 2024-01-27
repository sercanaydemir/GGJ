using System;
using UnityEngine;

namespace Player
{
    public class RagdollController : MonoBehaviour
    {
        Collider[] _colliders;
        Rigidbody[] _rigidbodies;
        [SerializeField] private Collider mainCollider;
        [SerializeField] private Rigidbody rigidbody;
        
        private void Awake()
        {
            _colliders = GetComponentsInChildren<Collider>();
            _rigidbodies = GetComponentsInChildren<Rigidbody>();
            DisableRagdoll();
        }
        
        void DisableRagdoll()
        {
            foreach (var collider in _colliders)
            {
                if(mainCollider != collider)
                    collider.enabled = false;
            }
            foreach (var rigidbody in _rigidbodies)
            {
                if(rigidbody != this.rigidbody)
                    rigidbody.isKinematic = true;
            }
        }
        
        void EnableRagdoll()
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = true;
            }
            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = false;
            }
        }
        
        private void OnEnable()
        {
            OnEnableRagdoll += EnableRagdoll;
        }
        
        private void OnDisable()
        {
            OnEnableRagdoll -= EnableRagdoll;
        }

        #region events

        public event Action OnEnableRagdoll;
        public void InvokeEnableRagdoll()
        {
            OnEnableRagdoll?.Invoke();
        }

        #endregion
        
    }
}