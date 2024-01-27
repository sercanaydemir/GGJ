using UnityEngine;
using UnityEngine.UI;

namespace MiniLevel.UI
{
    public class HealthBarUIController : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        
        private void Start()
        {
            healthBar.fillAmount = 1;
        }
        
        public void UpdateHealthBar(float health)
        {
            healthBar.fillAmount = health;
        }
        
    }
}