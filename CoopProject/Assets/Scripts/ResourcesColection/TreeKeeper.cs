using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ResourcesColection;
using Unity.VisualScripting;
using UnityEngine;

public class TreeKeeper: MonoBehaviour
{
    private Dictionary<Type, List<Resource>> _dictionary;

    private void Awake()
    {
        _dictionary = new ()
        {
            [typeof(Tree)] = new List<Resource>(),
            [typeof(Rock)] = new List<Resource>()
        };
    }

    public void Start()
    {
        _dictionary[typeof(Tree)] = new List<Resource>(FindObjectsOfType<Tree>());
        _dictionary[typeof(Rock)] = new List<Resource>(FindObjectsOfType<Rock>());
        
        Debug.Log(_dictionary[typeof(Tree)].Count);
        Debug.Log(_dictionary[typeof(Rock)].Count);
    }

    public List<Resource> GetList<T>()
    {
        return _dictionary[typeof(T)];
    }
}
