using System.Collections.Generic;
using HelperMashin;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class ResourceFinder : MonoBehaviour
{
    private List<ResourceTree> _resources;
    private TreeKeeper _treeKeeper;
    private float distance;
    private ResourceTree _resourceTree;

    public ResourceTree PointFindingObject => _resourceTree;
    
    
    [Inject]
    private void Construct(Container container)
    {
        _treeKeeper = container.Resolve<TreeKeeper>();
    }

    private void Start()=> _resources = _treeKeeper.GetList();
    
    public void Search(Transform pointFinding)
    {
        distance = Mathf.Infinity;
        Vector3 position = pointFinding.transform.position;

        foreach (ResourceTree resourceTree in _resources)
        {
            Vector3 direction = resourceTree.transform.position - position;
            float curDistance = direction.sqrMagnitude;

            if (curDistance < distance)
            {
                _resourceTree = resourceTree;
                Debug.Log(resourceTree);
                distance = curDistance;
            }
        }
    }
}