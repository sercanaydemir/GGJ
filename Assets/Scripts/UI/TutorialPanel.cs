using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class TutorialPanel : MonoBehaviour
    {
        [SerializeField] private List<GameObject> tutorials;

        private bool _isTutorialsClosed;

        private void Awake()
        {
            _isTutorialsClosed = false;
        }

        private void CloseTutorials()
        {
            if (_isTutorialsClosed) return;
            foreach (var tutorial in tutorials)
            {
                tutorial.SetActive(false);
            }
                
            _isTutorialsClosed = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
            {
                CloseTutorials();
            }
        }
    }
}