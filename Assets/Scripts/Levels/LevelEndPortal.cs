using System;
using DG.Tweening;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    public class LevelEndPortal : MonoBehaviour
    {
        [SerializeField] private int sceneIndex;
        [SerializeField] private Transform center;
        private void OnTriggerEnter(Collider other)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            if (playerController != null)
            {
                if(playerController.isDead) return;
                playerController.inputScheme.Player.Disable();
                playerController.transform.SetParent(center);
                playerController.transform.DOScale(Vector3.one * 0.1f, 2f);
                playerController.transform.DOLocalMove(Vector3.zero, 2f);
                OnLevelCompleted?.Invoke();
                Invoke(nameof(InvokeSceneLoad),2f);
            }
            
        }

        private void InvokeSceneLoad()
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public static event Action OnLevelCompleted;

    }
}