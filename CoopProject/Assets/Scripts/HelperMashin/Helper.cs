using System.Collections.Generic;
using ResourcesColection;
using UnityEngine;

public class Helper : MonoBehaviour
{
    private ResourceSource _resourceType;
    private List<ResourceSource> _resources;
    private int _damage = 10;
    private float _moveSpead;


    private void Start()
    {
        Search(transform);
    }

    public void Update()
    {
        if (_resourceType != null)
        {
            transform.position = 
                Vector3.MoveTowards(transform.position, _resourceType.transform.position,
                _moveSpead * Time.deltaTime);
        }
        else
        {
            Search(transform);
        }
    }

    private void Search(Transform pointFinding)
    {
        float distance = Mathf.Infinity;
        Vector3 position = pointFinding.transform.position;

        foreach (ResourceSource resourceTree in _resources)
        {
            Vector3 direction = resourceTree.transform.position - position;
            float curDistance = direction.sqrMagnitude;

            if (curDistance < distance)
            {
                _resourceType = resourceTree;
                distance = curDistance;
            }
        }
    }
    
    public void SetListResource(List<ResourceSource> _resourceObject)=> _resources = _resourceObject;
}