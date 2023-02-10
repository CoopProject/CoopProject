using System;
using DG.Tweening;
using UnityEngine;

public class MiningState : MonoBehaviour,IState
{
    [SerializeField] private FindingState _findingState;

    private Transform movePoint;
    
    private void Awake() => enabled = false;

    private void FixedUpdate()
    {
        
    }

    public void Enter()
    {
        enabled = true;
    }

    public void Exit()
    {
      
    }


    private void MoveToResource()
    {
        
    }
    
}
