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
        _putStack.onClick.AddListener(AddStack);
        _takeStack.onClick.AddListener(TakeStack);
        _takeResource.onClick.AddListener(TakeConvertType);
    }

    private void AddResource()=> AddResources<Log>();
    

    private void AddStack()=> SetStackCount<Log>();


    private void TakeStack()
    {
        var log = new Log();
        Take<Log>(log);
    }

    private void TakeConvertType()
    {
        if (_processor.Completed > 0)
        {
            Boards board = new();
            board.SetPrice();
            TakeResource<Boards>(board);
            Reset();
        }
    }
}