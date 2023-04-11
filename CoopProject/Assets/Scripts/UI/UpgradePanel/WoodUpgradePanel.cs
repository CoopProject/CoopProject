using Reflex;
using Reflex.Scripts.Attributes;

public class WoodUpgradePanel : UpgradePanelUI<Tree>
{
       
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    } 
}
