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
    private float _spead = 2.5f;
    private float _distanceEnterState = 1f;


    [Inject]
    private void Construct(Container container)
    {
        _helperStateMashin = container.Resolve<HelperStateMashin>();
    }

    private void Awake()
    {
        _findingResourse = GetComponent<FindingResourse>();
        enabled = false;
    }
    
    private void FixedUpdate()
    {
        transform.LookAt(movePoint.transform);
        transform.position =
            Vector3.MoveTowards(transform.position, movePoint.transform.position, _spead * Time.deltaTime);
        if (Vector3.Distance(transform.position,movePoint.transform.position) < _distanceEnterState)
        {
            _helperStateMashin.Enter<ExtractResourceState>();
        }
    }

    public void Enter()
    {
        _findingResourse.Finding(transform);
        movePoint = _findingResourse.PointFindingObject;
        enabled = true;
    }

    public void Exit()
    {
        enabled = false;
        movePoint = null;
    }
}
