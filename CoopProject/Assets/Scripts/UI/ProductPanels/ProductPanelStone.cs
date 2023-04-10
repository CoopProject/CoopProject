using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelStone : ProductPanel
{
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
    
    private void Start()
    {
        _putResource.onClick.AddListener(AddResource);
        _putStack.onClick.AddListener(AddAll);
        _takeStack.onClick.AddListener(TakeResourceBack);
        _takeResource.onClick.AddListener(TakeConvertType);
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