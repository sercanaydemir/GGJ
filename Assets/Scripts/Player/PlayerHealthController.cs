using System;
using MiniLevel.HealthSystem;
using MiniLevel.UI;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerHealthController : HealthSystemBase
    {
        [SerializeField] private HealthBarUIController healthBarUIController;

        protected override void Awake()
        {
            base.Awake();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            healthBarUIController.UpdateHealthBar((float) CurrentHealth / MaxHealth);

        }

        public override void Die()
        {
            base.Die();
            LevelEndPanel.InvokeOnLevelFailed();
            
        }
    }
}