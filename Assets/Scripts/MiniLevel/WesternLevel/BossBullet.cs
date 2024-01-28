using UnityEngine;

namespace MiniLevel.WesternLevel
{
    public class BossBullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed;
        
        private void FixedUpdate()
        {
            transform.Translate(Vector3.left * (bulletSpeed * Time.fixedDeltaTime),UnityEngine.Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}