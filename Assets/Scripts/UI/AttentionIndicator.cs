using System;
using System.Collections.Generic;
using System.Linq;
using Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AttentionIndicator : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private List<Transform> enemies;
        [SerializeField] private Transform player;
        
        private float t = 0.1f;

        private void Update()
        {
            if (enemies.Count > 0)
            {
                float minDistance = float.MaxValue;
                Transform closestEnemy = null;
                foreach (var enemy in enemies)
                {
                    float distance = Vector3.Distance(enemy.position, player.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestEnemy = enemy;
                    }
                }
                
                

                if (closestEnemy == null)
                    return;
                
                if (closestEnemy.position.z < player.position.z)
                {
                    enemies.Remove(closestEnemy);
                    return;
                }
                
                if (minDistance is < 25 and > 15)
                {
                    Color c = image.color;
                    c.a = 1 - GameUtil.Normalize(minDistance, 10, 20, 0, 1);
                    image.color = c;

                }
                else if (minDistance < 15)
                {
                    t -= Time.deltaTime;
                    if (t < 0)
                    {
                        t = 0.1f;
                        Color c = image.color;
                        c.a = c.a == 0 ? 1 : 0;
                        image.color = c;
                    }
                }
            }
            
            
        }
        private void RemoveEnemy(Transform obj)
        {
            if (enemies.Contains(obj))
                enemies.Remove(obj);
        }

        private void AddBarrel(Transform obj)
        {
            enemies.Add(obj);
        }

        private void OnEnable()
        {
            OnEnemyDead += RemoveEnemy;
            OnAddBarrel += AddBarrel;
        }

        private void OnDisable()
        {
            OnEnemyDead -= RemoveEnemy;
            OnAddBarrel -= AddBarrel;
        }


        public static event Action<Transform> OnEnemyDead;
        public static void InvokeEnemyDead(Transform enemy)
        {
            OnEnemyDead?.Invoke(enemy);
        }
        
        public static event Action<Transform> OnAddBarrel;
        public static void InvokeAddBarrel(Transform enemy)
        {
            OnAddBarrel?.Invoke(enemy);
        }
        
        
    }
}