using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelIronIngots : ProductPanel
{
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
   
    public void AddResource() => SetCount<Iron>();
    

    public void AddStack() => SetStackCount<Iron>();
    

    public void TakeStack() => Take();
    

    public void TakeConvertType()
    {
        IronIngots ironIngots = new();
        ironIngots.SetPrice();
        TakeResource<IronIngots>(ironIngots);
        Reset();
    }
}
