using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class OpenPanelIron : OpenPanel<Iron>
{
    private string _keyData = "IronStack";

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
        var iron = new Iron();
        SetResourceType(iron);
        _addResourceOne.onClick.AddListener(AddCoin);
        _addResourceTwo.onClick.AddListener(AddResourceOne);
    }

    private void Update()
    {
        if (!_objectActive)
        {
            ActiveBreadge<Iron>();    
        }
    } 
    
}