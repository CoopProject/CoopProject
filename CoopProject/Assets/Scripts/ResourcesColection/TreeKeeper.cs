using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeKeeper : MonoBehaviour 
{
    private Dictionary<Type, List<IExtracting>> _dictionary;

    private void Awake()
    {
        _dictionary = new Dictionary<Type, List<IExtracting>>
        {
            [typeof(Tree)] = new List<IExtracting>(),
            [typeof(Rock)] = new List<IExtracting>(),
        };
    }

    public void SetRecousrce<Type>(IExtracting tree)
    {
        _dictionary[typeof(Type)].Add(tree);
    }

    public void RemoveITemList<Type>(IExtracting tree)
    {
        _dictionary[typeof(Type)].Remove(tree);
    }

    public List<IExtracting> GetList<TResource>()  
    {
        return _dictionary[typeof(TResource)];
    }
}
