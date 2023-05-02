using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection.Gold_Ore;

public class GoldUpgradePanel : UpgradePanelUI<GoldOre>
{
    private const string _goldPanel = "GoldPanel";
    
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    } 
    
    private void Start()
    {
        _levelNow = _data.Load(_goldPanel);
        SetData();
     
        SetData();
        SetNexData();

        _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        _buttonLvlUpReward.onClick.AddListener(ShowReward);
        _buttonLvlUp.onClick.AddListener(LevelUp);
        _buttonLvlUpReward.onClick.AddListener(SaveData);
        _buttonLvlUp.onClick.AddListener(SaveData);
    }

    private void SaveData() => _data.Save(_goldPanel, _levelNow);
}
