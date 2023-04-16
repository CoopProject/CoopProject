using System.Collections.Generic;
using DefaultNamespace.Helper;
using ResourcesColection;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(HelperAnimator))]
public class Helper : MonoBehaviour
{
    private NavMeshAgent _agent;
    private ResourceSource _target;
    private List<ResourceSource> _resources;
    private HelperAnimator _animator;
    private int _damage = 5;
    private Vector3 offset = new Vector3(0, 2, 0);
    private float _extractDistance = 1.5f;
    private int _layerMask;
    private float _radius = 1f;
    private Collider[] _hits = new Collider[1];

    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<HelperAnimator>();
    }

    public void FixedUpdate() => MoveToPoint();

    private void MoveToPoint()
    {
        if (_target != null)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) >= _extractDistance)
            {
                var targetPosition = _target.transform.position + offset;
                _target.Occupy();
                _agent.SetDestination(targetPosition);
                _agent.isStopped = false;
                _animator.StopExtract();
                transform.LookAt(targetPosition);
            }
            else
            {
                _animator.Extract();
                _agent.isStopped = true;
                transform.LookAt(_target.transform.position + offset);
            }
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

        foreach (ResourceSource resource in _resources)
        {
            Vector3 direction = resource.transform.position - position;
            float curDistance = direction.sqrMagnitude;

            if (curDistance < distance && resource.IDead == false && resource.Free)
            {
                _target = resource;
                distance = curDistance;
            }
        }
    }

    public void SetList(List<ResourceSource> resourceSources) => _resources = resourceSources;

    public void ExtractResourceTarget() => ExtractResource(_damage);
    
    private void ExtractResource(int _damageEnemy)
    {
        if (Hit() > 0)
        {
            _hits[0].GetComponent<IResourceSource>().TakeDamage(_damageEnemy);
        }
        else
        {
            _animator.StopExtract();
            Search(transform);
        }
    }

    private int Hit() {
        return Physics.OverlapSphereNonAlloc(transform.position + transform.forward, _radius, _hits, _layerMask);
    }
}