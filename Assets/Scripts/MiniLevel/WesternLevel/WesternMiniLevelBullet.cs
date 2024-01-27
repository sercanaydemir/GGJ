using MiniLevel.Interfaces;
using UnityEngine;

namespace MiniLevel.WesternLevel
{
    public class WesternMiniLevelBullet : MonoBehaviour, IDestroyable
    {
        [SerializeField] private float bulletSpeed;
        
        private void FixedUpdate()
        {
            transform.Translate(Vector3.right * (bulletSpeed * Time.fixedDeltaTime),UnityEngine.Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}