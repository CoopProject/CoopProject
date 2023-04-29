using ResourcesColection.Gold_Ore;


namespace DefaultNamespace.Buildings
{
    public class HelperBuildingGold : HelpersBuilding<GoldOre>
    {
        private void Awake() => LevelPanel = _data.Load(KeyData);

        private void Start()
        {
            LevelUp(_panel.LevelUps[LevelPanel].InstanceHelpers, _panel.LevelUps[LevelPanel].ExtractedResources);
        }
    }
}