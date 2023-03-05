using System.Collections.Generic;
using ResourcesColection;
using UnityEngine;

public class Helper : MonoBehaviour
{
    private Resource _resourceType;
    private List<Resource> _resources;
    private int _damage = 10;
    private float _moveSpead = 3f;
    private Vector3 offset = new Vector3(0, 2, 0);
    private float _extractDistance = 2.5f;


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
        if (_resourceType != null &&
            Vector3.Distance(transform.position, _resourceType.transform.position) >= _extractDistance)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _resourceType.transform.position + offset,
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