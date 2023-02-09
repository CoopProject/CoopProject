using DG.Tweening;
using UnityEngine;

public class MiningState : MonoBehaviour
{
    public void Enter(ResourceTree resourceTree)
    {
        MovePoint(resourceTree);
    }

    private void MovePoint(ResourceTree pointMove)
    {
        transform.DOMove(pointMove.transform.position, 1f).onComplete();
    }
    
    
}