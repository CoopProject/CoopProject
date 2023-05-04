using ResourcesColection.Gold_Ore;
using UnityEngine;


namespace DefaultNamespace.Buildings
{
    public class HelperBuildingGold : HelpersBuilding<GoldOre>
    {
        private void Awake() => PlayerPrefs.GetInt(KeyData);

        private void Start()
        {
            LevelUp(_panel.LevelUps[LevelPanel].InstanceHelpers, _panel.LevelUps[LevelPanel].ExtractedResources);
        }
    }
}