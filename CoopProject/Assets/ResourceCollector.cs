using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Dictionary<Type, List<IResource>> _resources;

    private void Awake()
    {
        _resources = new Dictionary<Type, List<IResource>>()
        {
            [typeof(ResourceTree)] = new List<IResource>(),
            [typeof(ResourceRock)] = new List<IResource>(),
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        var tryGetComponent = other.TryGetComponent(out ResourceTree resourceTree);
        if (tryGetComponent)
        {
            _resources[typeof(ResourceTree)].Add(resourceTree);
            Take(resourceTree);
        }
        
        if (other.TryGetComponent(out ResourceRock resourceRock))
        {
            _resources[typeof(ResourceRock)].Add(resourceRock);
            Take(resourceRock);
        }
    
    }
    

    private void Take<TResource>( TResource resources) where TResource : MonoBehaviour,IResource
    {
        resources.gameObject.transform.DOMove(_player.transform.position, 1f).OnComplete(() =>
        {
           resources.gameObject.SetActive(false);
        });
    }

    public List<IResource> SetColectionResources<TResourceType>() where TResourceType: IResource
    {
        return _resources[typeof(TResourceType)].ToList();
    }
}