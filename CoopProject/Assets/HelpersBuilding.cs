using System.Collections.Generic;
using UnityEngine;

public class HelpersBuilding : MonoBehaviour
{
    [SerializeField] private SpawnHelperTree _spawnHelperTree;
    [SerializeField] private int _level = 0;
    [SerializeField] private List<Tree> _list;

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
