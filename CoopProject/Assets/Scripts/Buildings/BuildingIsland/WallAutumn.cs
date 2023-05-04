using DefaultNamespace.Buildings.BuildingIsland;
using UnityEngine;

public class WallAutumn : Wall
{
    [SerializeField] private OpenAutumnUI _openAutumn;

    private int _iDisable = 0;

    private void Start()
    {
        _iDisable = PlayerPrefs.GetInt(_openAutumn.DataKey);
        
        if (_iDisable == 1)
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
