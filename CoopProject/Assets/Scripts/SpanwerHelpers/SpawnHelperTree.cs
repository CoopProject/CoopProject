using System;
using System.Collections;
using Reflex;
using Reflex.Scripts.Attributes;
using SpanwerHelpers;
using UnityEngine;

internal class SpawnHelperTree : Factory
{
    private Helper _helper;
    private TreeKeeper _treeKeeper;

    [Inject]
    private void Construct(Container container)
    {
        _treeKeeper = container.Resolve<TreeKeeper>();
    }

    private void Start()
    {
        StartCoroutine(_SpawnHelper());
    }

    private IEnumerator _SpawnHelper()
    {
        yield return new WaitForSecondsRealtime(1f);
        _helper = GetHelper();
        var colection = _treeKeeper.GetList<Tree>();
        _helper.SetListResource(colection);
    }
}
