using System.Collections.Generic;
using HelperMashin;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class ResourceFinder : MonoBehaviour
{
    private List<IResource> _resources;
    private TreeKeeper _treeKeeper;
    private float distance;
    private Tree _tree;

    public Tree PointFindingObject => _tree;
    
    
    [Inject]
    private void Construct(Container container)
    {
        _treeKeeper = container.Resolve<TreeKeeper>();
    }

    private void Start()=> _resources = _treeKeeper.GetList<Tree>();
    
    public void Search(Transform pointFinding)
    {
        distance = Mathf.Infinity;
        Vector3 position = pointFinding.transform.position;

        foreach (Tree resourceTree in _resources)
        {
            Vector3 direction = resourceTree.transform.position - position;
            float curDistance = direction.sqrMagnitude;

            if (curDistance < distance)
            {
                _tree = resourceTree;
                Debug.Log(resourceTree);
                distance = curDistance;
            }
        }
    }
}