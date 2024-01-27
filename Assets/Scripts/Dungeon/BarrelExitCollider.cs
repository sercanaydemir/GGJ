using System;
using UnityEngine;

namespace Dungeon
{
    public class BarrelExitCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                BarrelSpawner.InvokeStopSpawner();
            }
        }
    }
}