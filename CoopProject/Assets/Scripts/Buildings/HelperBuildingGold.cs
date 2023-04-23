using ResourcesColection.Gold_Ore;
using UnityEngine;

public class HelperBuildingGold : HelpersBuilding<GoldOre>
{
    private void Awake()=> LevelPanel = _data.Load(KeyData);
    private void Start()
    {
        Levelup(_panel.LevelUps[LevelPanel].InstanceHelpers,_panel.LevelUps[LevelPanel].ExtractedResources);
    }
}
