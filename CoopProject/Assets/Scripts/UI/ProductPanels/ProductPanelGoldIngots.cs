using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelGoldIngots : ProductPanel
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
   
    private void AddResource() => AddResources<Gold>();
    

    private void AddStack()=> SetStackCount<Gold>();
    

    private void TakeStack() => Take();
    

    private void TakeConvertType()
    {
        GoldIngots goldenIngots = new();
        goldenIngots.SetPrice();
        TakeResource<GoldIngots>(goldenIngots);
        Reset();
    }
}
