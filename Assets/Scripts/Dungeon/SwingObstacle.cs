using System;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Dungeon
{
    public class SwingObstacle : MonoBehaviour
    {
        [SerializeField] private float rotateDuration = 5f;
        [SerializeField] private float rotateAngle = 90f;
        [SerializeField] private SwingDirection swingDirection;

        private void Start()
        {
            DORotate();
        }

        void DORotate()
        {
            Vector3 rotateVector = Vector3.zero;

            switch (swingDirection)
            {
                    case SwingDirection.X:
                    rotateVector = Vector3.right;
                    break;
                case SwingDirection.Y:
                    rotateVector = Vector3.up;
                    break;
                case SwingDirection.Z:
                    rotateVector = Vector3.forward;
                    break;
            }
            
            rotateVector *= rotateAngle;
            
            transform.DORotate(rotateVector, rotateDuration).SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.LogError("collide with player");
                PlayerController.InvokeDieWithCollideImpact(other.ClosestPoint(transform.position));
            }
        }
    }
    
    public enum SwingDirection
    {
        X,
        Y,
        Z
    }
}