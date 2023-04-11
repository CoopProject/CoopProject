using Reflex;
using Reflex.Scripts.Attributes;

public class StoneUpgradePanel : UpgradePanelUI<Rock>
{
    [Inject]
    private void Inject(Container container)
    {
        _playerWallet = container.Resolve<PlayerWallet>();
    } 
}
