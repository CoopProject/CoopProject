using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class StoneUpgradePanel : UpgradePanelUI<Rock>
{
    private const string _stonePanel = "StonePanel";
    
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    }
    
    private void OnEnable()
    {
        ButtonClick += SaveData;
    }

    private void Awake()=> _levelNow = PlayerPrefs.GetInt(_stonePanel);
    
    private void Start()
    {
        SetData();
        SetNexData();

        _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        _buttonLvlUpReward.onClick.AddListener(ShowReward);
        _buttonLvlUp.onClick.AddListener(LevelUp);
    }

    private void SaveData()=> PlayerPrefs.SetInt(_stonePanel, _levelNow);
    
    private void OnDisable()
    {
        ButtonClick -= SaveData;
    }
    
}
