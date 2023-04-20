using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection.Gold_Ore;

public class GoldUpgradePanel : UpgradePanelUI<GoldOre>
{
    [Inject]
    private void Inject(Container container) => _playerWallet = container.Resolve<PlayerWallet>();
    
}
