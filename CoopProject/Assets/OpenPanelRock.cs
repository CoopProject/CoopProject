using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;


public class OpenPanelRock : OpenPanel<Stone>
{
    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _player = container.Resolve<Player>();
    }
    
    private void Update()
    {
        ActiveBreadge<Stone>();
    }
        
    private void Start()
    {
        var stone = new Stone();
        SetResourceType(stone);
    }
}
