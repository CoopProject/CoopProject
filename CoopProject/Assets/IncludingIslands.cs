using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncludingIslands : MonoBehaviour
{
    [SerializeField] private List<Island> _islands;
    

    private void Start()
    {
        DisableAllIsland();
    }

    public void ActiveNextIsland(int Level)
    {
        if (Level < _islands.Count)
        {
            _islands[Level].ActiveIsland();
        }
    }

    private void DisableAllIsland()
    {
        foreach (var island in _islands)
        {
            island.DisableIsland();
        }
    }
}
