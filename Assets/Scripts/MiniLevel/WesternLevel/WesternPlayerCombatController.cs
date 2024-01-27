using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MiniLevel.WesternLevel
{
    public class WesternPlayerCombatController : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform bulletPoint;
        [SerializeField] private float shootCooldown;
        
        private InputScheme inputScheme;
        private float lastShotTime;
        private Vector3 originalPosition;
        private bool isRecoiling = false;
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
            if (Time.time - lastShotTime >= shootCooldown)
            {
                Instantiate(bullet, bulletPoint.position, Quaternion.identity);
                lastShotTime = Time.time;
                transform.DOMoveX(transform.position.x - 0.5f, 0.1f).OnComplete(() =>
                {
                    transform.DOMoveX(transform.position.x + 0.5f, 0.1f);
                });

            }
        }
        private void OnDisable()
        {
            inputScheme.Player.Disable();
        }
    }
}