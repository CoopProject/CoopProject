using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimatorPlayer _animator;

    private int _treeResourceCounter;
    private float _extractDuration = 1f;
    private static int _layerMask;
    private Collider[] _hits = new Collider[1];
    private float _radius = 0.3f;
    
    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out RecourceTree tree))
        {
            _extractDuration -= Time.deltaTime;
            if (_extractDuration < 0 && Hit() > 0)
            {
                Extract();
                _hits[0].gameObject.GetComponent<RecourceTree>().TakeDamage();
            }
        }
        else
        {
            _animator.StopExtract();
        }
    }
    

    public int Hit()
    {
      return  Physics.OverlapSphereNonAlloc(transform.position + transform.forward, _radius, _hits, _layerMask);
    }

    private void Extract()
    {
        _animator.Extract();
    }
}