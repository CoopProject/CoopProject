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
        _putStack.onClick.AddListener(AddStack);
        _takeStack.onClick.AddListener(TakeStack);
        _takeResource.onClick.AddListener(TakeConvertType);
    }

    private void AddResource()=> AddResources<Stone>();
    

    private void AddStack() => SetStackCount<Stone>();
    

    private void TakeStack() => Take();
    

    private void TakeConvertType()
    {
        StoneBlocks board = new();
        board.SetPrice();
        TakeResource<StoneBlocks>(board);
        Reset();
    }
}