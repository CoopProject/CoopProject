using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Dictionary<Type, List<IResource>> _colectionResource;

    private void Awake()
    {
        _colectionResource = new Dictionary<Type, List<IResource>>()
        {
            [typeof(ResourceTree)] = new List<IResource>(),
            [typeof(ResourceRock)] = new List<IResource>(),
        };
    }

    private void FixedUpdate()
    {
        Debug.Log($"{_colectionResource[typeof(ResourceTree)].Count} -" + $" Дерево)");
        Debug.Log($"{_colectionResource[typeof(ResourceRock)].Count} -" + $" Камень)");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ResourceTree _resourceTree))
        {
            _colectionResource[typeof(ResourceTree)].Add(_resourceTree);
            Take(_resourceTree);
        }
        
        if (other.TryGetComponent(out ResourceRock _resourceRock))
        {
            _colectionResource[typeof(ResourceRock)].Add(_resourceRock);
            Take(_resourceRock);
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