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
    private float _extractDistance = 2f;
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
            _target.Occupy();
            
            if (Vector3.Distance(transform.position, _target.transform.position) >= _extractDistance)
            {
                
                var targetPosition = _target.transform.position + offset;
                _agent.SetDestination(targetPosition);
                _agent.isStopped = false;
                _animator.StopExtract();
                _animator.Move();
                transform.LookAt(targetPosition);
                
                if (_target.Used)
                    _target = null;
            }
            else
            {
                RaycastHit hit;
                
                if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, _layerMask))
                {
                    _animator.StopMove();
                    _animator.Extract();
                    _agent.isStopped = true;
                }
                else
                    Search(transform);
                
                LookAtTarget();
            }
        }
        else
        {
            Search(transform);
            _agent.isStopped = true;
            _animator.StopMove();
            _animator.StopExtract();
        }
    }

    private void LookAtTarget()
    {
        var direction = _target.transform.position - transform.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(0,targetRotation.eulerAngles.y,0);
    }

    private void Search(Transform pointFinding)
    {
        float distance = Mathf.Infinity;
        Vector3 position = pointFinding.transform.position;

        foreach (ResourceSource resource in _resources)
        {
            Vector3 direction = resource.transform.position - position;
            float curDistance = direction.sqrMagnitude;

            if (curDistance < distance && !resource.IDead && resource.Free)
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
            _target = null;
        }
    }

    private int Hit() {
        return Physics.OverlapSphereNonAlloc(transform.position + transform.forward, _radius, _hits, _layerMask);
    }
}