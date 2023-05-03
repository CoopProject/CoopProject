using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class OpenPanelGold : OpenPanel<Gold>
{
    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _playerWallet = container.Resolve<PlayerWallet>();
    }
    
    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();
        SetStartData();
    }
    private void Start()
    {
        var gold = new Gold();
        SetResourceType(gold);
        _addResourceOne.onClick.AddListener(AddCoin);
        _addResourceTwo.onClick.AddListener(AddResourceTwo);
    }

    private void Update()
    {
        if (!_objectActive)
        {
            ActiveBreadge();    
        }
    }

}