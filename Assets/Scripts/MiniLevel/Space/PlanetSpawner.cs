using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MiniLevel.Space
{
    public class PlanetSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> planets;
        [SerializeField] private List<Transform> spawnPoints;

        [SerializeField] private float spawnInterval;

        private void Start()
        {
            StartCoroutine(PlanetSpawn());
        }

        private IEnumerator PlanetSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnInterval);
                int randomPlanet = Random.Range(0, planets.Count);
                int randomSpawnPoint = Random.Range(0, spawnPoints.Count);
                Instantiate(planets[randomPlanet], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            }
        } 
        
    }
}