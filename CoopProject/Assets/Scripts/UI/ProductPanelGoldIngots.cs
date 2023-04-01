using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelGoldIngots : ProductPanel
{
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
   
    public void AddResource()
    {
        SetCount<Gold>();
    }

    public void AddStack()
    {
        SetStackCount<Gold>();
    }

    public void TakeStack()
    {
        Take();
    }

    public void TakeConvertType()
    {
        GoldIngots goldenIngots = new();
        goldenIngots.SetPrice();
        TakeResource<GoldIngots>(goldenIngots);
        Reset<Gold>();
    }
}
