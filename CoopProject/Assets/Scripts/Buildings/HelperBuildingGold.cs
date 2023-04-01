using System.Collections.Generic;
using ResourcesColection.Gold_Ore;
using UnityEngine;

public class HelperBuildingGold : MonoBehaviour
{
    [SerializeField] private SpawnHelperGold _spawnHelperTree;
    [SerializeField] private int _level = 0;
    [SerializeField] private List<GoldOre> _list;

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
