using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelGoldIngots : ProductPanel
{
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
    
    private void Start()
    {
        _addResourceButton.onClick.AddListener(AddResource);
        //_addAllResourceButton.onClick.AddListener(AddStack);
        _takeResourceBackButton.onClick.AddListener(TakeStack);
        _takeResourceComplitButton.onClick.AddListener(TakeConvertType);
    }
   
    private void AddResource() => AddResources<Gold>();
    

   // private void AddStack()=> SetStackCount<Gold>();
    

    private void TakeStack()
    {
        var gold = new Gold();
       // Take<Log>(gold);
    }
    

    private void TakeConvertType()
    {
        GoldIngots goldenIngots = new();
        goldenIngots.SetPrice();
        TakeResource<GoldIngots>(goldenIngots);
        Reset();
    }
}
