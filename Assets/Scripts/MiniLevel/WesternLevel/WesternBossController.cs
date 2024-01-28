﻿using System;
using System.Collections;
using DG.Tweening;
using MiniLevel.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MiniLevel.WesternLevel
{
    public class WesternBossController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform bulletPoint;
        [SerializeField] private EnemyHealthController _enemyHealthController;
        
        
        
        private float _movementRange;
        private float _movementDelay;

        private bool bossSpecial = false;
        private float bossSpecialTimer;
        private void Start()
        {
            StartCoroutine(MoveAndWait());
            StartCoroutine(TriggerBossSpecial());
        }

        private IEnumerator TriggerBossSpecial()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(10f, 15f));
                
                if (!bossSpecial)
                {
                    BossSpecial();
                }
            }
        }

        private IEnumerator MoveAndWait()
        {
            while (!bossSpecial)
            {
                Dice();
                MoveVertical();
                yield return new WaitForSeconds(_movementDelay);
            }
        }

        private void MoveVertical()
        {
            transform.DOMoveY( _movementRange, movementSpeed).OnComplete(Dice);
        }
        private void Dice()
        {
            _movementDelay = Random.Range(.75f, 1f);
            _movementRange = Random.Range(-2.5f, 5f);
        }

        private void BossSpecial()
        {
            bossSpecial = true;
            
            OnBossSpecialAttack(!bossSpecial);
            
            transform.DOMoveY( 0.25f, 1f).OnComplete(() =>
            {
                transform.DOMoveX(2, 1f).OnComplete(() =>
                {
                    StartCoroutine(Attack());
                });
            });
        }
        
        private IEnumerator Attack ()
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(bullet, bulletPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(.25f);     
            }
            bossSpecial = false;
            
            OnBossSpecialAttack(!bossSpecial);
            
            transform.DOMoveX( 7, .5f).OnComplete(() =>
            {
                StartCoroutine(MoveAndWait());
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