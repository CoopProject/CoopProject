
using UnityEngine;

namespace DefaultNamespace.Buildings
{
    public class HelpersBuildingTree : HelpersBuilding<Tree>
    {
        private void Awake()=> LevelPanel = PlayerPrefs.GetInt(KeyData);
        

        private void Start()
        {
            LevelUp(_panel.LevelUps[LevelPanel].InstanceHelpers,_panel.LevelUps[LevelPanel].ExtractedResources);
        }
    }
}