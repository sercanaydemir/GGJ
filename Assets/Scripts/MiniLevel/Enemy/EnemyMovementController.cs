using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace MiniLevel.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;

        private float _movementRange;
        private float _movementDelay;

        private void Start()
        {
            StartCoroutine(MoveAndWait());
        }

        private IEnumerator MoveAndWait()
        {
            while (true)
            {
                Dice();
                transform.DOMove( new Vector3(transform.position.x + _movementRange, transform.position.y, transform.position.z), movementSpeed);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6.5f), transform.position.y, transform.position.z);
                yield return new WaitForSeconds(_movementDelay);
                
                
                
            }
        }

        private void Dice()
        {
            _movementDelay = Random.Range(.25f, .75f);
            //movementSpeed = Random.Range(1f, 3f);
            _movementRange = Random.Range(-5.5f, 5.5f);
        }
    }
}