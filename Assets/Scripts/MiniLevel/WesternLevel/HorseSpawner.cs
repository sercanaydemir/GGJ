using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

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
            float interval = spawnInterval;
            while (_canSpawnHorse)
            {
                yield return new WaitForSeconds(interval);
                GameObject h = Instantiate(horse, spawnPoint.position, quaternion.identity);
                
                interval = Random.Range(spawnInterval, spawnInterval + 1.5f);
                //h.transform.rotation = Quaternion.Euler(0, -90f, 0);
            }
        } 
    }
}