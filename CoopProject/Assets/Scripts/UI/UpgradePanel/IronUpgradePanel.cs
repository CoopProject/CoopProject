using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection.IronOre;

public class IronUpgradePanel : UpgradePanelUI<IronOre>
{
    [Inject]
    private void Inject(Container container)
    {
       // _player = container.Resolve<Player>();
    } 
}
