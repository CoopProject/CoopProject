using System.Collections;
using ResourcesColection.Gold_Ore;
using SpanwerHelpers;
using UnityEngine;

public class SpawnHelperGold : Factory<GoldOre>
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
        _helper.SetList<GoldOre>(_treeKeeper);
    }
}
