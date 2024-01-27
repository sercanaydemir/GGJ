using System;
using UnityEngine;

namespace Player
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private Vector3 offset;

        private void Start()
        {
            offset = transform.position - target.position;
        }
        
        private void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            //desiredPosition.y = transform.position.y;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed*Time.fixedDeltaTime);
            transform.position = smoothedPosition;
        }
    }
}