using System;
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

        private void Update()
        {
            ActiveBreadge<Log>();
        }

        private void Start()
        {
            var Log = new Log();
            SetResourceType(Log);
        }
    }
}