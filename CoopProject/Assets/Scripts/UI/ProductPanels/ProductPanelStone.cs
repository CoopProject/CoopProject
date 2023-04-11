using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelStone : ProductPanel
{
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
    
    private void Start()
    {
        _addResourceButton.onClick.AddListener(AddResource);
        _addAllResourceButton.onClick.AddListener(AddAll);
        _takeResourceBackButton.onClick.AddListener(TakeResourceBack);
        _takeResourceComplitButton.onClick.AddListener(TakeConvertType);
    }

    private void AddResource()=> AddResources<Stone>();
    

    private void AddAll()=> SellAllResource<Stone>();
    

    private void TakeResourceBack()
    {
        var stone = new Stone();
        TakeResource<Stone>(stone);
    }
    

    private void TakeConvertType()
    {
        if (_processor.Completed > 0)
        {
            StoneBlocks board = new();
            board.SetPrice();
            TakeResourceComplite<StoneBlocks>(board);
            Reset();
        }
    }
}