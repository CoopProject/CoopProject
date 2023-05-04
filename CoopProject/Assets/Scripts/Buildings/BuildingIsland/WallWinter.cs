using UnityEngine;

namespace DefaultNamespace.Buildings.BuildingIsland
{
    public class WallWinter : Wall
    {
        [SerializeField] private OpenWinterIsland _openWinter;

        private int _iDisable = 0;

        private void Start()
        {
            _iDisable = PlayerPrefs.GetInt(_openWinter.DataKey);
        
            if (_iDisable == 1)
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