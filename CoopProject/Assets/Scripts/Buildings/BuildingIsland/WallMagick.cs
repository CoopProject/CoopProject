using UnityEngine;

namespace DefaultNamespace.Buildings.BuildingIsland
{
    public class WallMagick : Wall
    {
        [SerializeField] private OpenMagickIsland _openMagickIsland;


        private int _iDisable = 0;

        private void Start()
        {
            _iDisable = PlayerPrefs.GetInt(_openMagickIsland.DataKey);
        
            if (_iDisable == 1)
            {
                _openMagickIsland.DisableWalls();
                Disable();
            }
        }

        public override void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}