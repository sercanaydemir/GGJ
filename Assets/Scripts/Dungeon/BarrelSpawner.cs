using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Dungeon
{
    public class BarrelSpawner : MonoBehaviour
    {
        [SerializeField] private Barrel barrelPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform groundFirstPosition;
        [SerializeField] private Transform groundEndPosition;
        private Coroutine spawnerRoutine;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                spawnerRoutine ??= StartCoroutine(StartSpawner());
            }
        }

        IEnumerator StartSpawner()
        {
            float t = 2.5f;
            while (true)
            {
                SpawnBarrel();
                yield return new WaitForSeconds(t);
            }

        }
        
        void StopSpawner()
        {
            if(spawnerRoutine == null) return;
            
            StopCoroutine(spawnerRoutine);
            spawnerRoutine = null;
        }
        
        private void SpawnBarrel()
        {
            Debug.LogError("wtf?");
            Barrel barrel = Instantiate(barrelPrefab, spawnPoint.position, Quaternion.Euler(0,0,90));
            barrel.StartMove(groundFirstPosition, groundEndPosition);
            AttentionIndicator.InvokeAddBarrel(barrel.transform);
        }

        private void OnEnable()
        {
            OnStopSpawner += StopSpawner;
        }
        
        private void OnDisable()
        {
            OnStopSpawner -= StopSpawner;
        }

        #region events

        public static event Action OnStopSpawner;
        
        public static void InvokeStopSpawner()
        {
            OnStopSpawner?.Invoke();
        }

        #endregion
    }
}