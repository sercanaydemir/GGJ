using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace MiniLevel.WesternLevel
{
    public class HorseSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject horse;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnInterval;

        private bool _canSpawnHorse;

        private void Awake()
        {
            _canSpawnHorse = true;
            
            WesternBossController.OnBossStatusChanged += OnBossStatusChanged;
        }

        private void OnDestroy()
        {
            WesternBossController.OnBossStatusChanged -= OnBossStatusChanged;
        }

        private void OnBossStatusChanged(bool obj)
        {
            _canSpawnHorse = obj;
            StartCoroutine(HorseSpawn());
        }

        private void Start()
        {
            StartCoroutine(HorseSpawn());
        }

        private IEnumerator HorseSpawn()
        {
            while (_canSpawnHorse)
            {
                yield return new WaitForSeconds(spawnInterval);
                GameObject h = Instantiate(horse, spawnPoint.position, quaternion.identity);
                
                h.transform.rotation = Quaternion.Euler(0, -90f, 0);
            }
        } 
    }
}