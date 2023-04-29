using Reflex;
using Reflex.Scripts.Attributes;

namespace DefaultNamespace.UI.UpgradePanel.WoodUpdates
{
    public class WoodUpgradePanelRockIsland : UpgradePanelUI<Tree>
    {
        private const string _rockIsland = "RockIsland";
        
        [Inject]
        private void Inject(Container container)
        {
            _playerWallet = container.Resolve<PlayerWallet>();
        }

        private void Awake() => _levelNow = _data.Load(_rockIsland);
        
        private void Start()
        {
            SetData();
            SetNexData();

            _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
            _buttonLvlUpReward.onClick.AddListener(ShowReward);
            _buttonLvlUp.onClick.AddListener(LevelUp);
        }
        private void FixedUpdate() => _data.Save(_rockIsland,_levelNow);
        
    }
}