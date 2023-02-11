using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ResourceTreeWatcher : MonoBehaviour 
{
    private Dictionary<Type, List<ResourceTree>> _dictionary;

    private void Awake()
    {
        _dictionary = new Dictionary<Type, List<ResourceTree>>
        {
            [typeof(ResourceTree)] = new List<ResourceTree>()
        };
    }

    public void SetTree<Type>(ResourceTree resourceTree)
    {
        _dictionary[typeof(Type)].Add(resourceTree);
    }

    public void RemoveITemList<Type>(ResourceTree resourceTree)
    {
        _dictionary[typeof(Type)].Remove(resourceTree);
        Debug.Log(_dictionary[typeof(Type)].Count);
    }

    public List<ResourceTree> GetList()
    {
        return _dictionary[typeof(ResourceTree)];
    }
}
