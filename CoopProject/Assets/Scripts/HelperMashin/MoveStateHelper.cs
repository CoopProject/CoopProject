using HelperMashin;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

[RequireComponent(typeof(ResourceFinder))]
public class MoveStateHelper : MonoBehaviour,IStateHelper
{
    private ResourceFinder _resourceFinder;
    private ResourceTree movePoint;
    private HelperStateMachine _helperStateMachine;
    private float _spead = 2.5f;
    private float _distanceEnterState = 1f;
    
    [Inject]
    private void Construct(Container container)
    {
        _helperStateMachine = container.Resolve<HelperStateMachine>();
    }

    private void Awake()
    {
        _resourceFinder = GetComponent<ResourceFinder>();
        enabled = false;
    }
    
    private void FixedUpdate()
    {
        transform.LookAt(movePoint.transform);
        transform.position =
            Vector3.MoveTowards(transform.position, movePoint.transform.position, _spead * Time.deltaTime);
        if (Vector3.Distance(transform.position,movePoint.transform.position) < _distanceEnterState)
        {
            _helperStateMachine.Enter<ExtractResourceState>();
        }
    }

    public void Enter()
    {
        _resourceFinder.Search(transform);
        movePoint = _resourceFinder.PointFindingObject;
        enabled = true;
    }

    public void Exit()
    {
        enabled = false;
        movePoint = null;
    }
}
