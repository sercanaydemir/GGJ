using System;
using System.Diagnostics;
using MiniLevel.Interfaces;
using Player;
using UnityEngine;

namespace MiniLevel.WesternLevel
{
    public class HorseMovementController : MonoBehaviour, IDestroyable
    {
        [SerializeField] private HorseMovementDirection horseMovementDirection;
        [SerializeField] private float horseMoveSpeed;
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            switch (horseMovementDirection)
            {
                case HorseMovementDirection.Up:
                    transform.Translate(Vector3.up * (Time.deltaTime * horseMoveSpeed), UnityEngine.Space.World);
                    break;
                case HorseMovementDirection.Down:
                    transform.Translate(Vector3.down * (Time.deltaTime * horseMoveSpeed), UnityEngine.Space.World);
                    break;
            }
        }
    }
    public enum HorseMovementDirection
    {
        Up,
        Down
    }
}