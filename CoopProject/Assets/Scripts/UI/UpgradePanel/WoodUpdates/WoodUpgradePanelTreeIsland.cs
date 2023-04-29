using Reflex;
using Reflex.Scripts.Attributes;

public class WoodUpgradePanelTreeIsland : UpgradePanelUI<Tree>
{
    private const string _treeIsland = "TreeIsland";
    
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void Awake()
    {
        _levelNow = _data.Load(_treeIsland); 
    }

    private void Start()
    {
        SetData();
        SetNexData();

        _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        _buttonLvlUpReward.onClick.AddListener(ShowReward);
        _buttonLvlUp.onClick.AddListener(LevelUp);
    }

    private void FixedUpdate() => _data.Save(_treeIsland, _levelNow);
    
}