using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;


public class OpenPanelRock : OpenPanel<Stone>
{
    private string _keyData = "StoneBlock";
    
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
        var stone = new Stone();
        SetResourceType(stone);
        _addResourceOne.onClick.AddListener(AddCoin);
        _addResourceTwo.onClick.AddListener(AddResourceOne);
    }

    private void Update()
    {
        ActiveBreadge<Stone>(); 
    }
}
