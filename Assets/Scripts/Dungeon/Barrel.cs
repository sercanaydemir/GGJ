using DG.Tweening;
using Player;
using UnityEngine;

namespace Dungeon
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] private float moveDuration = 4f;
        public void StartMove(Transform groundFirstPosition, Transform groundEndPosition)
        {
            transform.DOJump(groundFirstPosition.position, 3f, 1, 1f).SetEase(Ease.InSine).OnComplete(() =>
            {
                transform.DOMoveZ(groundEndPosition.position.z, moveDuration).SetEase(Ease.Linear).OnComplete(() =>
                {
                    Destroy(gameObject);
                });
            });
            
            
            transform.DORotate(new Vector3(-360,0,90),1,RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1,LoopType.Incremental);

        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.LogError("collide with player");
                PlayerController.InvokeDieWithCollideImpact(other.ClosestPoint(transform.position)+Vector3.up);
            }
        }
       
    }
}