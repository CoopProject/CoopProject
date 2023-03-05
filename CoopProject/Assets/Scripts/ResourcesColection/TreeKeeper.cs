using System;
using System.Collections.Generic;
using ResourcesColection;
using UnityEngine;

public class TreeKeeper: MonoBehaviour 
{
    private Dictionary<Type, List<ResourceSource>> _dictionary;

    private void Awake()
    {
        _dictionary = new Dictionary<Type, List<ResourceSource>>
        {
            [typeof(Tree)] = new List<ResourceSource>(),
            [typeof(Rock)] = new List<ResourceSource>(),
        };
    }

    public void SetRecousrce<Type>(ResourceSource tree)
    {
        _dictionary[typeof(Type)].Add(tree);
    }

    public void RemoveITemList<Type>(ResourceSource tree)
    {
        _dictionary[typeof(Type)].Remove(tree);
    }

    public List<ResourceSource> GetList<TResource>()  
    {
        return _dictionary[typeof(TResource)];
    }
}
