using Reflex;
using Reflex.Scripts.Attributes;

public class IronUpgradePanel : UpgradePanelUI
{
    [Inject]
    private void Inject(Container container)
    {
        _player = container.Resolve<Player>();
    } 
}
