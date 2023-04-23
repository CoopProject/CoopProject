using UnityEngine;

namespace DefaultNamespace.Buildings.BuildingIsland
{
    public class WallWinter : Wall
    {
        [SerializeField] private OpenWinterIsland _openWinter;
        [SerializeField] private GameData _data;

        private bool _iDisable = false;

        private void Start()
        {
            _iDisable = _data.LoadObject(_openWinter.DataKey);
        
            if (_iDisable)
            {
                _openWinter.DisableWalls();
                Disable();
            }
        }

        public override void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}