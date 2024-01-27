using System;
using Player;
using UnityEngine;

namespace Enemies
{
    public class Western_Bullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.LogError("trigger1");
            if (other.CompareTag("Player"))
            {
                Debug.LogError("trigger2");
                PlayerController.InvokeDieWithCollideImpact(other.ClosestPoint(transform.position));
            }
        }
    }
}