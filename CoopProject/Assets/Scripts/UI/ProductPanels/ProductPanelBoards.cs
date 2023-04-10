using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelBoards : ProductPanel
{
    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _player = container.Resolve<Player>();
    }

    private void Start()
    {
        _putResource.onClick.AddListener(AddResource);
        _putStack.onClick.AddListener(AddAll);
        _takeStack.onClick.AddListener(TakeResourceBack);
        _takeResource.onClick.AddListener(TakeConvertType);
    }

    private void AddResource()=> AddResources<Log>();
    
    
    private void AddAll()=> SellAllResource<Log>();


    private void TakeResourceBack()
    {
        var log = new Log();
        TakeResource<Log>(log);
    }

    private void TakeConvertType()
    {
        if (_processor.Completed > 0)
        {
            Boards board = new();
            board.SetPrice();
            TakeResourceComplite<Boards>(board);
            Reset();
        }
    }
}