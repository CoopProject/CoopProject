using System;
using HelperMashin;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class MoveStateHelper : MonoBehaviour,IStateHelper
{
    private FindingResourse
    private HelperStateMashin _helperStateMashin;
    private Transform movePoint;

    [Inject]
    private void Construct(Container container)
    {
        _helperStateMashin = container.Resolve<HelperStateMashin>();
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
