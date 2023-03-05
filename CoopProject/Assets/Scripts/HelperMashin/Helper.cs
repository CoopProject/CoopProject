using System.Collections.Generic;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection;
using UnityEngine;

public class Helper : MonoBehaviour 
{
    private Resource _resourceType;
    private List<Resource> _resources;
    private int _damage = 10;
    private float _moveSpead = 3f;


    public void FixedUpdate()
    {
        MoveToPoint();
    }

    private void Search(Transform pointFinding)
    {
        float distance = Mathf.Infinity;
        Vector3 position = pointFinding.transform.position;

        foreach (Resource resourceTree in _resources)
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

    private void MoveToPoint()
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

    public void SetList<T>(TreeKeeper treeKeeper)
    {
        _resources = treeKeeper.GetList<T>();
    }
}