using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

namespace DefaultNamespace.UI.OpenBuildings
{
    public class OpenPanelSawmill : OpenPanel<Log>
    {
        private string _keyData = "Samwiil";
        
        [Inject]
        private void Inject(Container container)
        {
            _resourceCollector = container.Resolve<ResourceCollector>();
            _playerWallet = container.Resolve<PlayerWallet>();
        }

        private void OnEnable()
        {
            KeyData = _keyData;
            _rectTransform = GetComponent<RectTransform>();
            SetStartData();
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
            if (!_objectActive)
            {
                ActiveBreadge<Log>();
            }
        }
    }
}