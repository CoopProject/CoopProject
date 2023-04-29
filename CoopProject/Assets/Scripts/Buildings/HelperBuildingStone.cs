namespace DefaultNamespace.Buildings
{
    public class HelperBuildingStone : HelpersBuilding<Rock>
    {
        private void Awake() => LevelPanel = _data.Load(KeyData);

        private void Start()
        {
            LevelUp(_panel.LevelUps[LevelPanel].InstanceHelpers, _panel.LevelUps[LevelPanel].ExtractedResources);
        }
    }
}