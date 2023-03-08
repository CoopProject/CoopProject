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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Gold gold))
            AddResource<Gold>(gold);
        
        if (other.TryGetComponent(out Log wood))
            AddResource<Log>(wood);
        
        if (other.TryGetComponent(out Stone stone))
            AddResource<Stone>(stone);
        
        if (other.TryGetComponent(out Iron iron))
            AddResource<Iron>(iron);
        
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