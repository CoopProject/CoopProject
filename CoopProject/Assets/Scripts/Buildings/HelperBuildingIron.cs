using ResourcesColection.IronOre;
using UnityEngine;

public class HelperBuildingIron : HelpersBuilding<IronOre>
{
    private void Awake()=> LevelPanel = _data.Load(KeyData);
    
    private void Start()
    {
        Levelup(_panel.LevelUps[LevelPanel].InstanceHelpers,_panel.LevelUps[LevelPanel].ExtractedResources);
    }
}
