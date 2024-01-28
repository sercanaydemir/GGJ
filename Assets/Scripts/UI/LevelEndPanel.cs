using System;
using DG.Tweening;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class LevelEndPanel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private string[] texts;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TextMeshProUGUI continueText;
        
        private int i=0;

        [SerializeField] private Sprite prettyMom;
        [SerializeField] private Sprite angryMom;
        [SerializeField] private Image momImage;

        private bool isWin = false;
        private bool isFail = false;

        private string nextText;
        private void LevelFailed()
        {
            momImage.sprite = angryMom;
            FadeIn();
            nextText = "'" +texts[Random.Range(0,texts.Length)] + "'";
        }
        
        private void LevelCompleted()
        {
            momImage.sprite = prettyMom;
            FadeIn();
            nextText = "Wake up boy, you are late for school!";
        }
        
        private void FadeIn()
        {
            DOTween.To(x=> _canvasGroup.alpha = x, 0, 1, 1f).OnComplete(WriteText);
        }

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                if (isFail)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        void WriteText()
        {
            text.DOText(nextText, 2).OnComplete(() =>
            {
                continueText.text = "Press any button to continue";
                isFail = true;
            });
        }
        void PlayerControllerOnOnDieWithCollideImpact(Vector2 obj)
        {
            LevelFailed();
        }

        private void OnEnable()
        {
            OnLevelFailed += LevelFailed;
            OnLevelCompleted += LevelCompleted;
            PlayerController.OnDieWithCollideImpact += PlayerControllerOnOnDieWithCollideImpact;

        }
        private void OnDisable()
        {
            OnLevelFailed -= LevelFailed;
            OnLevelCompleted -= LevelCompleted;
            PlayerController.OnDieWithCollideImpact -= PlayerControllerOnOnDieWithCollideImpact;
        }

        private static event Action OnLevelFailed;
        private static event Action OnLevelCompleted;
        
        public static void InvokeOnLevelFailed()
        {
            OnLevelFailed?.Invoke();
        }
        
        public static void InvokeOnLevelCompleted()
        {
            OnLevelCompleted?.Invoke();
        }
        
    }
}