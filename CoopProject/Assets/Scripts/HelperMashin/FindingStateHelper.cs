using System.Collections.Generic;
using HelperMashin;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class FindingStateHelper : MonoBehaviour,IStateHelper
{
    private List<ResourceTree> _resources;
    private ResourceTreeWatcher _resourceTreeWatcher;
    private float distance;
    private ResourceTree _resourceTree;
    private IHelper _helper;
    private IStateHelper _lastState;
    private HelperStateMashin _helperStateMashin;

    public FindingStateHelper(HelperStateMashin helperStateMashin)
    {
        _helperStateMashin = helperStateMashin;
    }

    public Vector3 PointFindingObject => _resourceTree.transform.position;
    
    
    [Inject]
    private void Construct(Container container)
    {
        _resourceTreeWatcher = container.Resolve<ResourceTreeWatcher>();
    }

    private void Start()=> _resources = _resourceTreeWatcher.GetList();

    public void Enter()
    {
        Finding();
        _helperStateMashin.Enter<FindingStateHelper>();
    }

    public void Exit() 
    {
        
    }

    private void Finding()
    {
        distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (ResourceTree resourceTree in _resources)
        {
            Vector3 direction = resourceTree.transform.position - position;
            float curDistance = direction.sqrMagnitude;

            if (curDistance < distance)
            {
                _resourceTree = resourceTree;
                distance = curDistance;
            }
        }
    }
}