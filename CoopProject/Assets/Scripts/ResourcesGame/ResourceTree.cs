using System;
using System.Collections;
using System.Collections.Generic;
using Reflex;
using Reflex.Scripts.Attributes;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceTree : MonoBehaviour,IResource
{

    private ResourceTreeWatcher _resourceTreeWatcher;
    private int _resourceValue = 15;
    private int _health = 10;
    private float _durationReset

    [Inject]
    private void Construct(Container container)
    {
        _resourceTreeWatcher = container.Resolve<ResourceTreeWatcher>();
    }

    private void Start()
    {
        _resourceTreeWatcher.SetTree<ResourceTree>(this);
    }

    public void TakeDamage(int damage)
    {
        _health -= 10;
        
    }

    private void Dead()
    {
        gameObject.SetActive(false);
    }


    private IEnumerator Reset()
    {
        var wait = New WaitForSecondsRealtime
    }
    
}