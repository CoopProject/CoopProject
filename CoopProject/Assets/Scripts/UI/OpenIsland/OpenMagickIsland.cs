using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class OpenMagickIsland : OpenIslandPanel<Iron,IronIngots>
{
    private Log _log;
    private Boards _boards;

    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _player = container.Resolve<Player>();
    }

    private void OnEnable()
    {
        SetStartData();
    }

    private void Update()
    {
        ActiveIsland();
    }

    public void AddCoin()
    {
        ValidateAdd();
        SetNewData();
    }

    public void AddResourceOne()
    {
        AddResourceOne<Iron>();
        SetNewData();
    }

    public void AddResourceTwo()
    {
        AddResourceTwo<IronIngots>();
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

    protected override void ActiveIsland()
    {
        if (CountCoin == MaxCountCountCoin && CountResourceOne == MaxCountCountOne &&
            CountResourceTwo == MaxCountCountTwo)
        {
            foreach (var wall in _walls)
            {
                wall.gameObject.SetActive(false);
            }
            
            _player.SellCoints(MaxCountCountCoin);
            _resourceCollector.SellCountResource<Iron>(CountResourceTwo);
            _resourceCollector.SellCountResource<IronIngots>(MaxCountCountTwo);
            Destroy(this.gameObject);
        }
    }
}
