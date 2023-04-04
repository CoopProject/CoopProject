using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class OpenPanelGold : OpenPanel<Gold>
{
    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _player = container.Resolve<Player>();
    }

    private void Start()
    {
        var gold = new Gold();
        SetResourceType(gold);
        _addResourceOne.onClick.AddListener(AddCoin);
        _addResourceTwo.onClick.AddListener(AddResourceOne);
    }

    private void Update()
    {
        ActiveBreadge<Gold>();
    }
}