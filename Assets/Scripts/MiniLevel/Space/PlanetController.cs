using MiniLevel.Interfaces;
using UnityEngine;

namespace MiniLevel.Space
{
    public class PlanetController : MonoBehaviour, IDestroyable
    {
        [SerializeField] private float planetMoveSpeed;
        
        private void FixedUpdate()
        {
            transform.Translate(Vector3.down * (planetMoveSpeed * Time.fixedDeltaTime),UnityEngine.Space.World);
            
            RotateAround();
        }
        
        private void RotateAround()
        {
            transform.Rotate( Vector3.forward * (planetMoveSpeed * 50*Time.fixedDeltaTime));
        }
    }
}