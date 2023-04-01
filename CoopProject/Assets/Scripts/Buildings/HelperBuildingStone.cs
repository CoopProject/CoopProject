using System.Collections;
using System.Collections.Generic;
using ResourcesGame.TypeResource;
using UnityEngine;

public class HelperBuildingStone : MonoBehaviour
{
    [SerializeField] private SpawnerHelperRock _spawnHelperTree;
    [SerializeField] private int _level = 0;
    [SerializeField] private List<Rock> _list;

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
