
namespace DefaultNamespace.Buildings
{
    public class HelpersBuildingTree : HelpersBuilding<Tree>
    {
        private void Awake()=> LevelPanel = _data.Load(KeyData);
        

        private void Start()
        {
            Levelup(_panel.LevelUps[LevelPanel].InstanceHelpers,_panel.LevelUps[LevelPanel].ExtractedResources);
        }
    }
}