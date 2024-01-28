using System;
using Player;
using UI;
using UnityEngine;

namespace Enemies
{
    public class WesternEnemyController : MonoBehaviour
    {
        [SerializeField] private WesternGun westernGun;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float shootDelay = 1f;
        [SerializeField] private float appliedShootDelay;
        [SerializeField] private float checkRadius;
        private RagdollController ragdollController;
        private Animator animator;
        private Rigidbody _rigidbody;
        private bool stopUpdate;
        private void Awake()
        {
            ragdollController = GetComponent<RagdollController>();
            animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if(stopUpdate) return;
            CheckFOV();
        }

        public void CheckFOV()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius, layerMask);
            if(hitColliders.Length > 0)
                Shoot();
        }

        private void Shoot()
        {
            if (appliedShootDelay > 0)
            {
                appliedShootDelay -= Time.deltaTime;
                return;
            }
            
            appliedShootDelay = shootDelay;
            animator.SetTrigger("shoot");
        }
        
        public void ShootBullet()
        {
            westernGun.Shoot();
        }

        public void Die(Vector3 obj)
        {
            Vector3 direction = new Vector3(obj.x,1,obj.y) - transform.position; 
            _rigidbody.AddForce(direction.normalized*5,ForceMode.Impulse);
            ragdollController.InvokeEnableRagdoll();
            animator.enabled = false;
            AttentionIndicator.InvokeEnemyDead(transform);
        }
        
        void PlayerDead(Vector2 obj)
        {
            stopUpdate = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, checkRadius);
        }

        private void OnEnable()
        {
            PlayerController.OnDieWithCollideImpact += PlayerDead;
        } 
        private void OnDisable()
        {
            PlayerController.OnDieWithCollideImpact -= PlayerDead;
        }
    }
}