using System;
using System.Collections.Generic;
using ResourcesColection;
using ResourcesColection.Tree;
using UnityEngine;
using Resource = ResourcesColection.Resource;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _sumAllPrice;

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
        // if (other.TryGetComponent(out Resource resourceTree))
        // {
        //     _resources[typeof(ResourceTree)].Add(resourceTree);
        //     Take(resourceTree);
        // }
        //
        // if (other.TryGetComponent(out Resource resourceRock))
        // {
        //     _resources[typeof(ResourceRock)].Add(resourceRock);
        //     Take(resourceRock);
        // }
    }

    public int CountColection<TResource>() where TResource : IResource
    {
        return _resources[typeof(TResource)].Count;
    }

    public void SellAllResource()
    {
        _resources[typeof(ResourceTree)] = new List<Resource>();
        _resources[typeof(ResourceRock)] = new List<Resource>();
    }
    
    private void Take( Resource resources) 
    {
        resources.gameObject.SetActive(false);
    }

    public int SumPriceAllResource<TypeResource>() where TypeResource: IResource
    {
        if (_resources[typeof(TypeResource)] != null)
        {
            foreach (var resource in _resources[typeof(TypeResource)])
            {
                return _sumAllPrice; // += resource.Price;
            }   
        }
        
        return 0;
    }
}