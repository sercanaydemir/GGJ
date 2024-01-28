using System;
using MiniLevel.UI;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MiniLevel.Space
{
    public class PlayerSpaceCombatController : MonoBehaviour
    {
        [SerializeField] private BulletController bullet;
        [SerializeField] private Transform bulletPoint;
        [SerializeField] private PlayerHealthController healthController;
        [SerializeField] private HealthBarUIController healthBarUIController;
        
        
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
            BulletController bulletController = Instantiate(bullet, bulletPoint.position, Quaternion.identity);
            bulletController.isBulletSelfMove = true;
            bulletController.targetTag = "Enemy";
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