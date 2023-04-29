using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelGoldIngots : ProductPanel
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
        _buttonLevelUpReward.onClick.AddListener(LevelUpReward);
    }
   
    private void AddResource()=> AddResources<Gold>();

    private void AddAll()=> SellAllResource<Gold>();

    private void TakeResourceBack() => TakeResource<Gold>();
    
    
    private void TakeConvertType()
    {
        if (_processor.Completed > 0)
        {
            TakeResourceComplite<GoldIngots>();
            Reset();
        }
    }
}
