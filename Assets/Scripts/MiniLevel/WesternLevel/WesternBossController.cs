using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MiniLevel.WesternLevel
{
    public class WesternBossController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;

        private float _movementRange;
        private float _movementDelay;

        private bool bossSpecial = false;
        private void Start()
        {
            StartCoroutine(MoveAndWait());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BossSpecial();
            }
        }

        private IEnumerator MoveAndWait()
        {
            while (!bossSpecial)
            {
                Dice();
                /*transform.DOMove( new Vector3(transform.position.x, transform.position.y  + _movementRange, transform.position.z), movementSpeed);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6.5f), transform.position.y, transform.position.z);*/
                MoveVertical();
                yield return new WaitForSeconds(_movementDelay);
            }
        }

        private void MoveVertical()
        {
            /*movementSpeed = Mathf.Abs(transform.position.x - _movementRange) * 2 ;*/ 
            transform.DOMoveY( _movementRange, movementSpeed).OnComplete(Dice);
        }
        private void Dice()
        {
            _movementDelay = Random.Range(.75f, 1f);
            //movementSpeed = Random.Range(1f, 3f);
            _movementRange = Random.Range(-2.5f, 5f);
        }

        private void BossSpecial()
        {
            //Debug.LogError("1");
            
            bossSpecial = true;
            
            OnBossSpecialAttack(!bossSpecial);
            
            transform.DOMoveY( 0, 1f).OnComplete(() =>
            {
                //Debug.LogError("2");
                
                transform.DOMoveX( 2, 1f).OnComplete(() =>
                {
                   // Debug.LogError("3");
                   
                   OnBossSpecialAttack(bossSpecial);
                   
                    bossSpecial = false;
                   
                });
            });
        }

        #region Events

        public static event Action<bool> OnBossStatusChanged;
        
        private void OnBossSpecialAttack(bool bossAttack)
        {
            Debug.LogError("Boss Attack: " + bossAttack);
            OnBossStatusChanged?.Invoke(bossAttack);
        }

        #endregion
    }
}