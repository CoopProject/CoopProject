using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeKeeper : MonoBehaviour 
{
    private Dictionary<Type, List<IResource>> _dictionary;

    private void Awake()
    {
        _dictionary = new Dictionary<Type, List<IResource>>
        {
            [typeof(Tree)] = new List<IResource>(),
            [typeof(Rock)] = new List<IResource>(),
        };
    }

    public void SetRecousrce<Type>(IResource tree)
    {
        _dictionary[typeof(Type)].Add(tree);
    }

    public void RemoveITemList<Type>(IResource tree)
    {
        _dictionary[typeof(Type)].Remove(tree);
    }

    public List<IResource> GetList<TResource>()  
    {
        return _dictionary[typeof(TResource)];
    }
}
