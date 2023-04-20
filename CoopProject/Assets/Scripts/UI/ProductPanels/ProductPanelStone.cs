using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelStone : ProductPanel
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
        _buttonLevelUpReward.onClick.AddListener(ShowReward);
        _close.onClick.AddListener(Close);
    }

    private void AddResource()=> AddResources<Stone>();
    

    private void AddAll()=> SellAllResource<Stone>();
    

    private void TakeResourceBack()
    {
        TakeResource<Stone>();
    }
    

    private void TakeConvertType()
    {
        if (_processor.Completed > 0)
        {
            TakeResourceComplite<StoneBlocks>();
            Reset();
        }
    }
}