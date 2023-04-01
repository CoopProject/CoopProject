using System.Collections;
using ResourcesColection.IronOre;
using SpanwerHelpers;
using UnityEngine;

public class SpawnHelperIron : Factory<IronOre>
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
        _helper.SetList<IronOre>(_treeKeeper);
    }
}
