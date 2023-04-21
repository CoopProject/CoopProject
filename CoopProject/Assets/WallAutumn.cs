using System;
using UnityEngine;

public class WallAutumn : MonoBehaviour
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

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
