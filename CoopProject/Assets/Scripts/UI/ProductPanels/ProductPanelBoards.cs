using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelBoards : ProductPanel
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

    private void AddResource()=> AddResources<Log>();
    
    private void AddAll()=> SellAllResource<Log>();
    
    private void TakeResourceBack()
    {
        TakeResource<Log>();
    }

    private void TakeConvertType()
    {
        if (_processor.Completed > 0)
        {
            TakeResourceComplite<Boards>();
            Reset();
        }
    }
}