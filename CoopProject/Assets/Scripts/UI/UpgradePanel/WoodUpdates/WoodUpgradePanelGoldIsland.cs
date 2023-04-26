using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

namespace DefaultNamespace.UI.UpgradePanel.WoodUpdates
{
    public class WoodUpgradePanelGoldIsland : UpgradePanelUI<Tree>
    {
        [Inject]
        private void Inject(Container container)
        {
            _playerWallet = container.Resolve<PlayerWallet>();
        }

        private void Awake()
        {
            _levelNow = _data.Load("GoldIsland"); 
        }

        private void Start()
        {
            SetData();
            SetNexData();

            _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
            _buttonLvlUpReward.onClick.AddListener(ShowReward);
            _buttonLvlUp.onClick.AddListener(LevelUp);
        }

        private void FixedUpdate()
        {
            _data.Save("GoldIsland", _levelNow);
        }
    }
}