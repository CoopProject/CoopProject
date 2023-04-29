using ResourcesColection.IronOre;

namespace DefaultNamespace.Buildings
{
    public class HelperBuildingIron : HelpersBuilding<IronOre>
    {
        private void Awake() => LevelPanel = _data.Load(KeyData);

        private void Start()
        {
            LevelUp(_panel.LevelUps[LevelPanel].InstanceHelpers, _panel.LevelUps[LevelPanel].ExtractedResources);
        }
    }
}