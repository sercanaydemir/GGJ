using System.Security.Cryptography;
using MiniLevel.Interfaces;
using UnityEngine;

namespace MiniLevel.Space
{
    public class BulletController : MonoBehaviour, IDestroyable
    {
        [SerializeField] private float bulletSpeed;
        
        private void FixedUpdate()
        {
            transform.Translate(Vector3.up * (bulletSpeed * Time.fixedDeltaTime),UnityEngine.Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}

////////////////////////---------------------------------------------------------////////////////////////
//TODO: Planet and player collision, fail
//TODO: Boss health bar
////////////////////////---------------------------------------------------------////////////////////////