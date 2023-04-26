using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection.Gold_Ore;

public class GoldUpgradePanel : UpgradePanelUI<GoldOre>
{
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    } 
    
    private void Start()
    {
        _levelNow = _data.Load("GoldPanel");
        SetData();
     
        SetData();
        SetNexData();

        _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        _buttonLvlUpReward.onClick.AddListener(ShowReward);
        _buttonLvlUp.onClick.AddListener(LevelUp);
    }
    private void FixedUpdate()
    {
        _data.Save("GoldPanel",_levelNow);
    }
}
