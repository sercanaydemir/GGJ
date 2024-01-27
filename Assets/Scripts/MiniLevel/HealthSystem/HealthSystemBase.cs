﻿using MiniLevel.Interfaces;
using UnityEngine;

namespace MiniLevel.HealthSystem
{
    public abstract class HealthSystemBase : MonoBehaviour,IDamageable
    {
        [SerializeField] private int maxHealth;
        
        private int _currentHealth;
        
        protected virtual void Awake()
        {
            Init();
        }
        protected virtual void Init()
        {
            _currentHealth = maxHealth;
        }
        public virtual void TakeDamage(int damage)
        {
            if (_currentHealth > 0)
            {
                _currentHealth -= damage;    
            }
            
            if (_currentHealth <= 0)
            {
                Die();
            }    
        }

        public virtual void Die()
        {
            //Character death system
        }
        
    }
}