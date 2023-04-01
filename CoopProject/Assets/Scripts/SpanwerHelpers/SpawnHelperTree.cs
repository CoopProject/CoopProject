using System.Collections;
using SpanwerHelpers;
using UnityEngine;

internal class SpawnHelperTree : Factory<Tree>
{
    private Helper _helper;

    private int _counterInstance = 0;

    public int CounterInstance => _counterInstance;

    public IEnumerator Instance()
    {
        yield return new WaitForSecondsRealtime(3f);
        _counterInstance++;
        _helper = GetHelperInstantiate();
        _helper.SetList<Tree>(_treeKeeper);
    }
}
