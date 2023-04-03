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
            [typeof(StoneBlocks)] = new List<Resource>(),
            [typeof(Boards)] = new List<Resource>(),
            [typeof(Iron)] = new List<Resource>(),
            [typeof(IronIngots)] = new List<Resource>(),
            [typeof(GoldIngots)] = new List<Resource>(),
        };
    }

    public void AddResource<TypeResource>( Resource resource)
    {
        _resources[typeof(TypeResource)].Add(resource);
    }

    public int GetCountList<TypeResource>()
    {
        var count = _resources[typeof(TypeResource)].Count;
        return count;
    }

    public int GetResourcePrice<TypeResource>()
    {
        if (_resources[typeof(TypeResource)].Count > 0)
            return _resources[typeof(TypeResource)][0].Price;
        
        return 0;
    }

    public void SallResource<TypeResource>()
    {
        _resources[typeof(TypeResource)].Clear();
    }
    
    public void SellCountResource<TypeResource>(int countResource)
    {
        _resources[typeof(TypeResource)].RemoveRange(0,countResource);
    }
}