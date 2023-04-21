using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection.IronOre;

public class IronUpgradePanel : UpgradePanelUI<IronOre>
{
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    } 
    
    private void Start()
    {
        _levelNow = _data.Load("IronPanel");
        SetData();
     
        SetData();
        SetNexData();

        _helpersBuilding.Levelup(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        _buttonLvlUpReward.onClick.AddListener(ShowReward);
        _buttonLvlUp.onClick.AddListener(LevelUp);
        _closeWindow.onClick.AddListener(Close);
    }
    private void FixedUpdate()
    {
        _data.Save("IronPanel",_levelNow);
    }
}
