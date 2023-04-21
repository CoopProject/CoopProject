
public class HelperBuildingStone : HelpersBuilding<Rock>
{
    private void Awake()=> LevelPanel = _data.Load(KeyData);
    
    private void Start()
    {
        Levelup(_panel.LevelUps[LevelPanel].InstanceHelpers,_panel.LevelUps[LevelPanel].ExtractedResources);
    }
}
