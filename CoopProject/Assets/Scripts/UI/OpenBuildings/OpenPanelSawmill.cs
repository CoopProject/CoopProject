using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

namespace DefaultNamespace.UI.OpenBuildings
{
    public class OpenPanelSawmill : OpenPanel<Log>
    {
        [Inject]
        private void Inject(Container container)
        {
            _resourceCollector = container.Resolve<ResourceCollector>();
            _player = container.Resolve<Player>();
        }

        private void Start()
        {
            var Log = new Log();
            SetResourceType(Log);
            _addResourceOne.onClick.AddListener(AddCoin);
            _addResourceTwo.onClick.AddListener(AddResourceOne);
        }

        private void Update()
        {
            ActiveBreadge<Log>();
        }
    }
}