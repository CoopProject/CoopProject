using System;
using System.Collections.Generic;
using ResourcesColection;
using SpanwerHelpers;
using UnityEngine;

public class HelpersBuilding<T> : MonoBehaviour where T : ResourceSource
{
    [SerializeField] protected Factory<T> _spawnHelperTree;
    [SerializeField] protected List<ResourceSource> _list;
    [SerializeField] protected UpgradePanelUI<T> _panel;
    [SerializeField] protected GameData _data;
    [SerializeField] protected string KeyData = "TreeIsland";

    protected int LevelPanel = 0;
    public int Counter => _spawnHelperTree.InstanceCount;
    public void Levelup(int helperInstance, int resourceExtraction)
    {
        while (Counter <= helperInstance - 1)
        {
            var helper = _spawnHelperTree.GetHelperInstantiate();
            helper.SetList(_list);
        }
        LevelUpExtraction(resourceExtraction);
    }
    
    private void LevelUpExtraction(int extraction)
    {
        for (int i = 0; i < _list.Count; i++)
            _list[i].AddResourceCount(extraction);
    }
}
