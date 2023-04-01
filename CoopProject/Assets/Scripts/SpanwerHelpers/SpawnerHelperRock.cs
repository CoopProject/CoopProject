using System.Collections;
using System.Collections.Generic;
using SpanwerHelpers;
using UnityEngine;

public class SpawnerHelperRock : Factory<Rock>
{
    private Helper _helper;

    public void Start()
    {
        StartCoroutine(Instance());
    }

    private IEnumerator Instance()
    {
        yield return new WaitForSecondsRealtime(3f);
        _helper = GetHelperInstantiate();
        _helper.SetList<Rock>(_treeKeeper);
    }
}
