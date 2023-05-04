using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

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
        
        private void OnEnable()
        {
            ButtonClick += SaveData;
        }

        private void Awake() => _levelNow = PlayerPrefs.GetInt(_rockIsland);

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

        private void SaveData() => PlayerPrefs.SetInt(_rockIsland, _levelNow);
        
        private void OnDisable()
        {
            ButtonClick -= SaveData;
        }
    }

}