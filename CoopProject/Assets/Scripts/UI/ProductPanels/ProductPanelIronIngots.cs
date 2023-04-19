using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelIronIngots : ProductPanel
{
    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void Start()
    {
        _addResourceButton.onClick.AddListener(AddResource);
        _addAllResourceButton.onClick.AddListener(AddAll);
        _takeResourceBackButton.onClick.AddListener(TakeResourceBack);
        _takeResourceComplitButton.onClick.AddListener(TakeConvertType);
        _buttonLevelUp.onClick.AddListener(LevelUp);
    }
   
    private void AddResource()=> AddResources<Iron>();
    

    private void AddAll()=> SellAllResource<Iron>();
    

    private void TakeResourceBack()
    {
        var iron = new Iron();
        TakeResource<Iron>();
    }
    

    private void TakeConvertType()
    {
        if (_processor.Completed > 0)
        {
            IronIngots ironIngots = new();
            ironIngots.SetPrice();
            TakeResourceComplite<IronIngots>();
            Reset();
        }
    }
}
