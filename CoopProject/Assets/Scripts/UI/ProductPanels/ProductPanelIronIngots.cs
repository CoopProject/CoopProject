using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelIronIngots : ProductPanel
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
   
    private void AddResource() => AddResources<Iron>();
    

   //private void AddStack() => SetStackCount<Iron>();
    

    private void TakeStack()
    {
        var iron = new Iron();
        //Take<Log>(iron);
    }

    private void TakeConvertType()
    {
        IronIngots ironIngots = new();
        ironIngots.SetPrice();
        TakeResource<IronIngots>(ironIngots);
        Reset();
    }
}
