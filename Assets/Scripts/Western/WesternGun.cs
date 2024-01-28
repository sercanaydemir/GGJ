using System;
using DG.Tweening;
using MiniLevel.Space;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class WesternGun : MonoBehaviour
    {
        [SerializeField] private Transform shootPoint;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Vector3 shootAxis = Vector3.forward;
        [SerializeField] private bool ship;
        [SerializeField] private float shootDuration = 50f;
        float attackDelay = 1f;
        private void Update()
        {
            if (ship)
            {
                attackDelay -= Time.deltaTime;
                if (attackDelay <= 0)
                {
                    attackDelay = Random.Range(0.25f, 1f);
                    Shoot();
                }
            }
        }

        public void Shoot()
        {
            Transform bullet = Instantiate(bulletPrefab, shootPoint.position, quaternion.identity).transform;

            bullet.DOMove(shootPoint.position - shootAxis*30f, shootDuration);

            BulletController bulletController = bullet.GetComponent<BulletController>();

            if (bulletController)
            {
                bulletController.targetTag = "Player";
            }
        }
    }
}