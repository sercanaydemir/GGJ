using System.Security.Cryptography;
using MiniLevel.Enemy;
using MiniLevel.Interfaces;
using Player;
using UnityEngine;

namespace MiniLevel.Space
{
    public class BulletController : MonoBehaviour, IDestroyable
    {
        [SerializeField] private float bulletSpeed;
        public string targetTag;
        public bool isBulletSelfMove = false;
        private void FixedUpdate()
        {
            if (isBulletSelfMove)
            {
                transform.Translate(Vector3.up * (bulletSpeed * Time.fixedDeltaTime),UnityEngine.Space.World);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            EnemyHealthController enemyHealthController = other.GetComponentInParent<EnemyHealthController>();
            if(enemyHealthController != null)
            {
                enemyHealthController.Damage();
                gameObject.SetActive(false);
                return;
            }
            
            PlayerHealthController playerHealthController = other.GetComponentInParent<PlayerHealthController>();

            if(playerHealthController != null)
            {
                playerHealthController.TakeDamage(1);
                gameObject.SetActive(false);
                return;
            }
            
            if (other.CompareTag(targetTag))
            {
                Destroy(other.gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}

////////////////////////---------------------------------------------------------////////////////////////
//TODO: Planet and player collision, fail
//TODO: Boss health bar
////////////////////////---------------------------------------------------------////////////////////////