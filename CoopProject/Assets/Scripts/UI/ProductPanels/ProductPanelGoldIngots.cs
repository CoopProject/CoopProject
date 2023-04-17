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
        _addAllResourceButton.onClick.AddListener(AddAll);
        _takeResourceBackButton.onClick.AddListener(TakeResourceBack);
        _takeResourceComplitButton.onClick.AddListener(TakeConvertType);
        _buttonLevelUp.onClick.AddListener(LevelUp);
    }
   
    private void AddResource()=> AddResources<Stone>();
    

    private void AddAll()=> SellAllResource<Stone>();
    

    private void TakeResourceBack()
    {
        var gold = new Gold();
        TakeResource<Gold>(gold);
    }
    

    private void TakeConvertType()
    {
        if (_processor.Completed > 0)
        {
            GoldIngots goldIngots = new();
            goldIngots.SetPrice();
            TakeResourceComplite<GoldIngots>(goldIngots);
            Reset();
        }
    }
}
