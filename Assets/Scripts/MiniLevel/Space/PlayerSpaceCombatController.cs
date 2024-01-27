using System;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MiniLevel.Space
{
    public class PlayerSpaceCombatController : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform bulletPoint;

        [SerializeField] private PlayerHealthController healthController;

        
        
        InputScheme inputScheme;

        private void Awake()
        {
            inputScheme = new InputScheme();
        }

        private void OnEnable()
        {
            inputScheme.Player.Enable();
            
            inputScheme.Player.MainCombat.performed += Shoot;
        }
        private void Shoot(InputAction.CallbackContext obj)
        {
            Instantiate(bullet, bulletPoint.position, Quaternion.identity);
        }

        private void OnDisable()
        {
            inputScheme.Player.Disable();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                healthController.TakeDamage(1);
            }
        }
    }
}