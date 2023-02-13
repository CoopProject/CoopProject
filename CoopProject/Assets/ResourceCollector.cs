using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Dictionary<Type, List<ResourceTree>> _colectionTree;

    private void Awake()
    {
        _colectionTree = new Dictionary<Type, List<ResourceTree>>()
        {
            [typeof(ResourceTree)] = new List<ResourceTree>(),
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ResourceTree _resource))
        {
            _colectionTree[typeof(ResourceTree)].Add(_resource);
            Take(_resource);
        }

    }
    

    private void Take<TResource>( TResource resourec) where TResource : MonoBehaviour,IResource
    {
        resourec.gameObject.transform.DOMove(_player.transform.position, 1f).OnComplete(() =>
        {
           resourec.gameObject.SetActive(false);
        });
    }
}
