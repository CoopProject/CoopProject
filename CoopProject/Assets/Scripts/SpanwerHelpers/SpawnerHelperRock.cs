using System.Collections;
using System.Collections.Generic;
using SpanwerHelpers;
using UnityEngine;

public class SpawnerHelperRock : Factory<Rock>
{
    private Helper _helper;
    
    private int _counterInstance = 0;

    public int CounterInstance => _counterInstance;

    public void Instance()
    {
        _counterInstance++;
        _helper = GetHelperInstantiate();
        _helper.SetList<Tree>(_treeKeeper);
    }
}
