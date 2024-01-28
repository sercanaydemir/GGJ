using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private static DontDestroyOnLoad _instance;
        private void Awake()
        {
            if(_instance == null)
                _instance = this;
            else
                Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject);
        }
    }
}