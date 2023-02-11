using System;
using HelperMashin;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

[RequireComponent(typeof(FindingResourse))]
public class MoveStateHelper : MonoBehaviour,IStateHelper
{
    private FindingResourse _findingResourse;
    private ResourceTree movePoint;
    private HelperStateMashin _helperStateMashin;
    private float _spead = 0;


    [Inject]
    private void Construct(Container container)
    {
        _helperStateMashin = container.Resolve<HelperStateMashin>();
    }

    private void Awake() => _findingResourse = GetComponent<FindingResourse>();

    private void FixedUpdate()
    {
        if (movePoint == null)
                 return;
        transform.LookAt(movePoint.transform);
        

    }

    public void Enter()
    {
        movePoint = _findingResourse?.Finding(transform);
    }

    public void Exit()
    {
      
    }
}
