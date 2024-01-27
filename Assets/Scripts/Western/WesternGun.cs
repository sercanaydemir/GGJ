using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies
{
    public class WesternGun : MonoBehaviour
    {
        [SerializeField] private Transform shootPoint;
        [SerializeField] private GameObject bulletPrefab;
        public void Shoot()
        {
            Transform bullet = Instantiate(bulletPrefab, shootPoint.position, quaternion.identity).transform;

            bullet.DOMove(shootPoint.position - Vector3.forward*30f, 50f);
        }
    }
}