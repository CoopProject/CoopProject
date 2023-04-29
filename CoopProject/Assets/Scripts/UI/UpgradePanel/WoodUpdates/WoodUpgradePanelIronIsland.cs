using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection.IronOre;
using UnityEngine;

namespace DefaultNamespace.UI.UpgradePanel.WoodUpdates
{
    public class WoodUpgradePanelIronIsland : UpgradePanelUI<Tree>
    {
        private const string _ironIsland = "IronIsland";
        
        
        [Inject]
        private void Inject(Container container)
        {
            _playerWallet = container.Resolve<PlayerWallet>();
        }

        private void Awake() => _levelNow = _data.Load(_ironIsland);
        
        private void Start()
        {
            SetData();
            SetNexData();

            _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
            _buttonLvlUpReward.onClick.AddListener(ShowReward);
            _buttonLvlUp.onClick.AddListener(LevelUp);
        }
        private void FixedUpdate() => _data.Save(_ironIsland,_levelNow);
        
    }
}