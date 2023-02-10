using System.Collections.Generic;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class FindingState : MonoBehaviour,IState
{
   [SerializeField] private MiningState _miningState;
    private List<ResourceTree> _resources;
    private ResourceTreeWatcher _resourceTreeWatcher;
    private float distance;
    private ResourceTree _resourceTree;
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
        _miningState.Enter();
        this.enabled = false;
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