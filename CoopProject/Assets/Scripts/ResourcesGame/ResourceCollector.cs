using System;
using System.Collections.Generic;
using ResourcesGame.TypeResource;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    

    private Dictionary<Type, List<IResource>> _resources;

    private void Awake()
    {
        _resources = new Dictionary<Type, List<IResource>>()
        {
            [typeof(Gold)] = new List<IResource>(),
            [typeof(Log)] = new List<IResource>(),
            [typeof(Stone)] = new List<IResource>(),
            [typeof(Iron)] = new List<IResource>(),
        };
    }

    private void AddResource<TypeResource>( IResource resource)
    {
        _resources[typeof(TypeResource)].Add(resource);
    }

    public int GetCountList<TypeResource>()
    {
        return _resources[typeof(TypeResource)].Count;
    }
}