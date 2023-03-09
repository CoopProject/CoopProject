using System;
using System.Collections;
using Reflex;
using Reflex.Scripts.Attributes;
using SpanwerHelpers;
using Unity.VisualScripting;
using UnityEngine;

internal class SpawnHelperTree : Factory<Tree>
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
        _helper.SetList<Tree>(_treeKeeper);
    }
}
