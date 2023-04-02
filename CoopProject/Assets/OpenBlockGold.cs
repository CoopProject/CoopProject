using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class OpenBlockGold : OpenPanel
{
    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _player = container.Resolve<Player>();
    }
    
    private void Update()
    {
        ActiveBreadge();
    }
    
    public void AddCoin()
    {
        ValidateAdd();
        SetNewData();
    }

    public void AddResourceOne()
    {
        AddResourceOne<Gold>();
        SetNewData();
    }
    
    private bool ValidateAdd()
    {
        if (_player.Coins > MaxCountCountCoin)
        {
            CountCoin = MaxCountCountCoin;
            return true;
        }

        CountCoin = _player.Coins;
        return false;
    }

    protected override void ActiveBreadge()
    {
        if (CountCoin == MaxCountCountCoin && CountResourceOne == MaxCountResourceOne )
        {
            _building.gameObject.SetActive(true);
            _player.SellCoints(MaxCountCountCoin);
            _resourceCollector.SellCountResource<Gold>(MaxCountResourceOne);
            Destroy(this.gameObject);
            Destroy(_tarpaulin.gameObject);
        } 
    }
}
