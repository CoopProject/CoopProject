using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Helper;
using ResourcesColection;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(HelperAnimator))]
public class Helper : MonoBehaviour
{
    private NavMeshAgent _agent;
    private ResourceSource _resourceSourceType;
    private List<ResourceSource> _resources;
    private HelperAnimator _animator;
    private int _damage = 5;
    private Vector3 offset = new Vector3(0, 2, 0);
    private float _extractDistance = 2.5f;
    private ExtractResourceService _extractResource;
    private int _layerMask;
    private float _radius = 0.3f;

    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
        _extractResource = new ExtractResourceService(transform, _layerMask, _radius);
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<HelperAnimator>();
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

            if (curDistance < distance && resource.IDead == false)
            {
                _resourceSourceType = resource;
                distance = curDistance;
            }
        }
    }

    private void MoveToPoint()
    {
        if (_resourceSourceType != null &&
            Vector3.Distance(transform.position, _resourceSourceType.transform.position) >= _extractDistance)
        {
            _resourceSourceType.PrivateResource();
            var targetPosition = _resourceSourceType.transform.position + offset;
            _agent.SetDestination(targetPosition);
            _agent.isStopped = false;
            _animator.StopExtract();
            transform.LookAt(targetPosition);
        }
        else
        {
            Search(transform);
            _animator.Extract();
            _agent.isStopped = true;
        }
    }

    public void SetList<T>(TreeKeeper treeKeeper)
    {
        _resources = treeKeeper.GetList<T>();
    }

    public void ExtractResours() => _extractResource.ExtractResource(_damage);
}