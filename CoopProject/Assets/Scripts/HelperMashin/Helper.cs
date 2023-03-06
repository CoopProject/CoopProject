using System;
using System.Collections.Generic;
using DefaultNamespace;
using ResourcesColection;
using UnityEngine;

public class Helper : MonoBehaviour
{
    private Resource _resourceType;
    private List<Resource> _resources;
    private int _damage = 30;
    private float _moveSpead = 3f;
    private Vector3 offset = new Vector3(0, 2, 0);
    private float _extractDistance = 2.5f;
    private float _extractDuration = 0;
    private float _maxExtctractDuration = 3f;
    private ExtractResourceService _extractResource;
    private int _layerMask;
    private float _radius = 0.3f;

    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
        _extractResource = new ExtractResourceService(transform, _layerMask,_radius);
    }


    public void FixedUpdate()
    {
        MoveToPoint();
    }

    private void Search(Transform pointFinding)
    {
        float distance = Mathf.Infinity;
        Vector3 position = pointFinding.transform.position;

        foreach (Resource resource in _resources)
        {
            Vector3 direction = resource.transform.position - position;
            float curDistance = direction.sqrMagnitude;

            if (curDistance < distance && resource.IDead != true)
            {
                _resourceType = resource;
                distance = curDistance;
            }
        }
    }

    private void MoveToPoint()
    {
        if (_resourceType != null && Vector3.Distance(transform.position, _resourceType.transform.position) >= _extractDistance)
        {
            var targetPosition = _resourceType.transform.position + offset;
            transform.position =
                Vector3.MoveTowards(transform.position,targetPosition,
                    _moveSpead * Time.deltaTime);
            transform.LookAt(targetPosition);
        }
        else
        {
            Search(transform);
           ExtractResours();
        }
    }

    public void SetList<T>(TreeKeeper treeKeeper)
    {
        _resources = treeKeeper.GetList<T>();
    }

    private void ExtractResours()
    {
        _extractDuration -= Time.deltaTime;
        
        if (_extractDuration <= 0)
        {
            _extractDuration = _maxExtctractDuration;
            _extractResource.ExtractResource(_damage);
        }
    }
}