using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class ProductPanelStone : ProductPanel
{
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();

    public void AddResource()
    {
        SetCount<Stone>();
    }

    public void AddStack()
    {
        SetStackCount<Stone>();
    }

    public void TakeStack()
    {
        Take();
    }

    public void TakeConvertType()
    {
        StoneBlocks board = new();
        board.SetPrice();
        TakeResource<StoneBlocks>(board);
        Reset();
    }
}