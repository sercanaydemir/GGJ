using System;
using Player;
using UnityEngine;

namespace Enemies
{
    public class FailCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))  
                PlayerController.InvokeDieWithCollideImpact(other.ClosestPoint(transform.position));
        }
    }
}