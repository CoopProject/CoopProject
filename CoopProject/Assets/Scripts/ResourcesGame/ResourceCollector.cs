using System;
using System.Collections.Generic;
using ResourcesGame.TypeResource;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    

    private Dictionary<Type, List<Resource>> _resources;

    private void Awake()
    {
        _resources = new Dictionary<Type, List<Resource>>()
        {
            [typeof(Gold)] = new List<Resource>(),
            [typeof(Log)] = new List<Resource>(),
            [typeof(Stone)] = new List<Resource>(),
            [typeof(Iron)] = new List<Resource>(),
        };
    }

    public void AddResource<TypeResource>( Resource resource)
    {
        _resources[typeof(TypeResource)].Add(resource);
    }

    public int GetCountList<TypeResource>()
    {
        return _resources[typeof(TypeResource)].Count;
    }
}