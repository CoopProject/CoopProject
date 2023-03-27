using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ResourcesColection;
using Unity.VisualScripting;
using UnityEngine;

public class TreeKeeper: MonoBehaviour
{
    private Dictionary<Type, List<ResourceSource>> _dictionary;

    private void Awake()
    {
        _dictionary = new ()
        {
            [typeof(Tree)] = new List<ResourceSource>(),
            [typeof(Rock)] = new List<ResourceSource>()
        };
    }

    public void Start()
    {
        _dictionary[typeof(Tree)] = new List<ResourceSource>(FindObjectsOfType<Tree>());
        _dictionary[typeof(Rock)] = new List<ResourceSource>(FindObjectsOfType<Rock>());
    }

    public List<ResourceSource> GetList<T>()
    {
        return _dictionary[typeof(T)];
    }
}
