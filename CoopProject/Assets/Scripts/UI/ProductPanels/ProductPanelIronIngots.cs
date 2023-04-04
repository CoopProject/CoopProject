using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelIronIngots : ProductPanel
{
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
    
    private void Start()
    {
        _putResource.onClick.AddListener(AddResource);
        _putStack.onClick.AddListener(AddStack);
        _takeStack.onClick.AddListener(TakeStack);
        _takeResource.onClick.AddListener(TakeConvertType);
    }
   
    private void AddResource() => AddResources<Iron>();
    

    private void AddStack() => SetStackCount<Iron>();
    

    private void TakeStack() => Take();
    

    private void TakeConvertType()
    {
        IronIngots ironIngots = new();
        ironIngots.SetPrice();
        TakeResource<IronIngots>(ironIngots);
        Reset();
    }
}
