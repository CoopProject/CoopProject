using System;
using HelperMashin;
using UnityEngine;

public class MoveStateHelper : MonoBehaviour,IStateHelper
{
    private HelperStateMashin _helperStateMashin;
    private Transform movePoint;

    public MoveStateHelper(HelperStateMashin helperStateMashin)
    {
        _helperStateMashin = helperStateMashin;
    }

    private void Awake() => enabled = false;

    private void FixedUpdate()
    {
        if (movePoint == null)
                 return;
        transform.LookAt(movePoint);
        
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
      
    }
}
