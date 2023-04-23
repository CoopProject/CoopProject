using UnityEngine;

namespace DefaultNamespace.Buildings.BuildingIsland
{
    public class WallMagick : Wall
    {
        [SerializeField] private OpenMagickIsland _openAutumn;
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
}