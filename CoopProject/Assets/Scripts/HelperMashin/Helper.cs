using System.Collections.Generic;
using DefaultNamespace;
using ResourcesColection;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Helper : MonoBehaviour
{
    private NavMeshAgent _agent;
    private ResourceSource _resourceSourceType;
    private List<ResourceSource> _resources;
    private int _damage = 30;
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
        _agent = GetComponent<NavMeshAgent>();
    }
    
    public void FixedUpdate()
    {
        MoveToPoint();
    }

    private void Search(Transform pointFinding)
    {
        float distance = Mathf.Infinity;
        Vector3 position = pointFinding.transform.position;

        foreach (ResourceSource resource in _resources)
        {
            Vector3 direction = resource.transform.position - position;
            float curDistance = direction.sqrMagnitude;

            if (curDistance < distance && resource.IDead != true)
            {
                _resourceSourceType = resource;
                distance = curDistance;
            }
        }
    }

    private void MoveToPoint()
    {
        if (_resourceSourceType != null && Vector3.Distance(transform.position, _resourceSourceType.transform.position) >= _extractDistance)
        {
            var targetPosition = _resourceSourceType.transform.position + offset;
            _agent.SetDestination(targetPosition);
            _agent.isStopped = false;
            transform.LookAt(targetPosition);
        }
        else
        {
            Search(transform);
           ExtractResours();
           _agent.isStopped = true;
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