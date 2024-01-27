using System;
using MiniLevel.HealthSystem;
using MiniLevel.UI;
using UnityEngine;

namespace MiniLevel.Enemy
{
    public class EnemyHealthController : HealthSystemBase
    {
        [SerializeField] private HealthBarUIController healthBarUIController;
        
        protected override void Awake()
        {
            base.Awake();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                TakeDamage(1);
                healthBarUIController.UpdateHealthBar((float) _currentHealth / maxHealth);
            }
        }
    }
}