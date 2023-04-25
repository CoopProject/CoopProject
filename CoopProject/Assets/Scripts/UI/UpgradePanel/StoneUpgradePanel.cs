using System;
using Reflex;
using Reflex.Scripts.Attributes;

public class StoneUpgradePanel : UpgradePanelUI<Rock>
{
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void Awake()=> _levelNow = _data.Load("StonePanel");
    

    private void Start()
    {
        SetData();
        SetNexData();

        _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        _buttonLvlUpReward.onClick.AddListener(ShowReward);
        _buttonLvlUp.onClick.AddListener(LevelUp);
        /*_closeWindow.onClick.AddListener(Close);*/
    }
    private void FixedUpdate()
    {
        _data.Save("StonePanel",_levelNow);
    }
}
