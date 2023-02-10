using System.Collections.Generic;
using UnityEngine;

public class FindingState : MonoBehaviour,IState
{
    [SerializeField] private List<ResourceTree> _resources;
    [SerializeField] private MiningState _miningState;
    
    private float distance;
    private ResourceTree _resourceTree;

    public void Enter()
    {
        var findingObject = Finding();
        _miningState.Enter(findingObject);
    }

    //inject
    public void Exit() 
    {
        
        
    }

    private ResourceTree Finding()
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

        return _resourceTree;
    }
}