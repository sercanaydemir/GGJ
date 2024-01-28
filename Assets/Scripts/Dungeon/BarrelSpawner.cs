using System;
using System.Collections;
using DG.Tweening;
using Player;
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
        [SerializeField] private float spawnInterval = 2.5f;
        [SerializeField] private float barrowMoveDuration = 4f;
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
            while (true)
            {
                SpawnBarrel();
                yield return new WaitForSeconds(spawnInterval);
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
            Barrel barrel = Instantiate(barrelPrefab, spawnPoint.position, Quaternion.Euler(0,0,90));
            barrel.moveDuration = barrowMoveDuration;
            barrel.StartMove(groundFirstPosition, groundEndPosition);
            AttentionIndicator.InvokeAddBarrel(barrel.transform);
        }

        private void OnEnable()
        {
            OnStopSpawner += StopSpawner;
            PlayerController.OnDieWithCollideImpact += DieWithCollideImpact;

        }
        
        private void OnDisable()
        {
            OnStopSpawner -= StopSpawner;
            PlayerController.OnDieWithCollideImpact -= DieWithCollideImpact;

        }

        private void DieWithCollideImpact(Vector2 obj)
        {
            StopSpawner();
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