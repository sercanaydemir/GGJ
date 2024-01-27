using System;
using MiniLevel.Interfaces;
using UnityEngine;

namespace MiniLevel.Managers
{
    public class DestroyerManager : MonoBehaviour
    { 
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDestroyable destroyable))
            {
                Destroy(other.gameObject);
            }
        }
    }
}