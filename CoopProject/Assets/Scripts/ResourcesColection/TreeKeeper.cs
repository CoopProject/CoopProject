using System;
using System.Collections.Generic;
using ResourcesColection;
using ResourcesColection.Gold_Ore;
using ResourcesColection.IronOre;
using UnityEngine;

public class TreeKeeper: MonoBehaviour
{
    private Dictionary<Type, List<ResourceSource>> _dictionary;

    private void Awake()
    {
        _dictionary = new ()
        {
            [typeof(Tree)] = new List<ResourceSource>(),
            [typeof(Rock)] = new List<ResourceSource>(),
            [typeof(GoldOre)] = new List<ResourceSource>(),
            [typeof(IronOre)] = new List<ResourceSource>(),
        };
    }

    public void Start()
    {
        _dictionary[typeof(Tree)] = new List<ResourceSource>(FindObjectsOfType<Tree>());
        _dictionary[typeof(Rock)] = new List<ResourceSource>(FindObjectsOfType<Rock>());
        _dictionary[typeof(GoldOre)] = new List<ResourceSource>(FindObjectsOfType<GoldOre>());
        _dictionary[typeof(IronOre)] = new List<ResourceSource>(FindObjectsOfType<IronOre>());
    }

    public List<ResourceSource> GetList<T>()
    {
        return _dictionary[typeof(T)];
    }
}
