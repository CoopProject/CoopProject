using UnityEngine;

namespace DefaultNamespace.Buildings
{
    public class HelperBuildingStone : HelpersBuilding<Rock>
    {
        private void Awake() => LevelPanel = PlayerPrefs.GetInt(KeyData);

        private void Start()
        {
            LevelUp(_panel.LevelUps[LevelPanel].InstanceHelpers, _panel.LevelUps[LevelPanel].ExtractedResources);
        }
    }
}