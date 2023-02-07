using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private TreeResource _resource;

    private int _atackCount = 5;
    private int _resourceValue = 15;
    private float _direction = 1f;
    
    private void OnValidate()
    {
        IResource recource = _resource;

        if (recource == null)
            _resource = null;
    }

    public void TakeDamage()
    {
        
    }
    
}