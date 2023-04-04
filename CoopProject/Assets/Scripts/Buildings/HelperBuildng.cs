using System.Collections.Generic;
using ResourcesColection;
using UnityEngine;

namespace DefaultNamespace.Buildings
{
    public class HelperBuildng<T> : MonoBehaviour  where T:ResourceSource
    {
    [SerializeField] protected SpawnerHelperRock _spawnHelperTree;
    [SerializeField] protected int _level = 0;
    [SerializeField] protected List<T> _list;

    public int Counter => _spawnHelperTree.CounterInstance;
    public int Level => _level;

    public void Lvlup()
    {
        _spawnHelperTree.Instance();
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