using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using ResourcesColection;
using ResourcesColection.Tree;
using ResourcesGame;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Dictionary<Type, List<Resource>> _resources;

    private void Awake()
    {
        _resources = new Dictionary<Type, List<Resource>>()
        {
            [typeof(ResourceTree)] = new List<Resource>(),
            [typeof(ResourceRock)] = new List<Resource>(),
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ResourceTree resourceTree))
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
    

    private void Take( Resource resources) 
    {
        resources.gameObject.SetActive(false);
    }

    public List<Resource> SetColectionResources<TResourceType>() where TResourceType: Resource
    {
        return _resources[typeof(TResourceType)].ToList();
    }
}