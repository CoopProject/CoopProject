using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class ProductPanelBoards : ProductPanel
{
    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _player = container.Resolve<Player>();
    }

    public void AddResource()
    {
        AddResources<Log>();
    }

    public void AddStack()
    {
        SetStackCount<Log>();
    }

    public void TakeStack()
    {
        Take();
    }

    public void TakeConvertType()
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