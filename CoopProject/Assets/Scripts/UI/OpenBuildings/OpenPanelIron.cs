using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class OpenPanelIron : OpenPanel<Iron>
{
    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _player = container.Resolve<Player>();
    }
    
    private void Update()
    {
        ActiveBreadge<Iron>();
    }
        
    private void Start()
    {
        var iron = new Iron();
        SetResourceType(iron);
    }
}
