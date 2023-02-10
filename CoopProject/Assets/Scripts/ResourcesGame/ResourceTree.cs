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

    [Inject]
    private void Construct(Container container)
    {
        _resourceTreeWatcher = container.Resolve<ResourceTreeWatcher>();
    }

    private void Awake()
    {
        _resourceTreeWatcher.SetTree<ResourceTree>(this);
    }

    public void TakeDamage()
    {
        
    }
    
}