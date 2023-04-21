using ResourcesGame.TypeResource;
using UnityEngine;

namespace DefaultNamespace.Buildings.Tarpuilns
{
    public class TarpaulinStoneBlock : Tarpaulin<Stone>
    {
        private void Start()
        {
            ActiveBuilding();
        }
    }
}