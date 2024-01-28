using System;
using MiniLevel.HealthSystem;
using MiniLevel.UI;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniLevel.Enemy
{
    public class EnemyHealthController : HealthSystemBase
    {
        [SerializeField] private HealthBarUIController healthBarUIController;
        
        protected override void Awake()
        {
            base.Awake();
        }
        public void Damage()
        {
            TakeDamage(1);
            healthBarUIController.UpdateHealthBar((float) _currentHealth / maxHealth);
        }
        
        public override void Die()
        {
            base.Die();
            gameObject.SetActive(false);
            
            int sceneIndex = SceneManager.GetActiveScene().buildIndex +1;
            if(sceneIndex < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(sceneIndex);
            else 
                LevelEndPanel.InvokeOnLevelCompleted();
        }
    }
}