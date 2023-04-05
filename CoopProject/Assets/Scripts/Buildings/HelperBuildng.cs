using System.Collections.Generic;
using ResourcesColection;
using SpanwerHelpers;
using UnityEngine;

namespace DefaultNamespace.Buildings
{
    public class HelperBuildng<T> : MonoBehaviour  where T:ResourceSource
    {
    [SerializeField] protected Factory<T> _spawnHelperTree;
    [SerializeField] protected int _level = 0;
    [SerializeField] protected List<ResourceSource> _list;

    public int Counter => _spawnHelperTree.InstanceCount;
    public int Level => _level;

    public void Lvlup()
    {
       var helper =  _spawnHelperTree.GetHelperInstantiate();
       helper.SetList(_list);
        _level++;
        LevelUpExtraction();
    }

    private void LevelUpExtraction()
    {
        for (int i = 0; i < _list.Count; i++)
            _list[i].AddResourceCount();

    }
    }
}