using System;
using DefaultNamespace.Buildings.BuildingIsland;
using UnityEngine;

public class WallAutumn : Wall
{
    [SerializeField] private OpenAutumnUI _openAutumn;
    [SerializeField] private GameData _data;

    private bool _iDisable = false;

    private void Start()
    {
        _iDisable = _data.LoadObject(_openAutumn.DataKey);
        
        if (_iDisable)
        {
            _openAutumn.DisableWalls();
            Disable();
        }
    }

    public override void Disable()
    {
        gameObject.SetActive(false);
    }
}
