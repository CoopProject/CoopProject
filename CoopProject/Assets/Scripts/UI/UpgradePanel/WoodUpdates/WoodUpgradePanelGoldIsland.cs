using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

namespace DefaultNamespace.UI.UpgradePanel.WoodUpdates
{
    public class WoodUpgradePanelGoldIsland : UpgradePanelUI<Tree>
    {
        private const string _goldIsland = "GoldIsland";
        
        [Inject]
        private void Inject(Container container)
        {
            _playerWallet = container.Resolve<PlayerWallet>();
        }

        private void Awake()
        {
            _levelNow = _data.Load(_goldIsland); 
        }

        private void Start()
        {
            SetData();
            SetNexData();

            _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
            _buttonLvlUpReward.onClick.AddListener(ShowReward);
            _buttonLvlUp.onClick.AddListener(LevelUp);
            _buttonLvlUpReward.onClick.AddListener(SaveData);
            _buttonLvlUp.onClick.AddListener(SaveData);
        }

        private void SaveData() => _data.Save(_goldIsland, _levelNow);
        
    }
}