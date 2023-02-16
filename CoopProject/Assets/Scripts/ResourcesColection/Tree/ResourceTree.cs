using System;
using UnityEngine;

public class ResourceTree: MonoBehaviour, IResource
{
    private int value;
    
    public int Value => value;
}