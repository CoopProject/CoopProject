using Reflex;
using Reflex.Scripts.Attributes;

public class StoneUpgradePanel : UpgradePanelUI
{
    [Inject]
    private void Inject(Container container)
    {
        _player = container.Resolve<Player>();
    } 
}
