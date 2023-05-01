using Reflex;
using Reflex.Scripts.Attributes;

public class StoneUpgradePanel : UpgradePanelUI<Rock>
{
    private const string _stonePanel = "StonePanel";
    
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void Awake()=> _levelNow = _data.Load(_stonePanel);
    
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

    private void SaveData() => _data.Save(_stonePanel, _levelNow);
}
