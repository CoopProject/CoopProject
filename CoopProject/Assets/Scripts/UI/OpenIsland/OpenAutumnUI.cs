using DefaultNamespace.MVP.MVPShop.Viues;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class OpenAutumnUI : OpenIslandPanel<Log, Boards>
{
    [SerializeField] private StatsSetup _statsSetup;
    
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
        AddResourceOne<Log>();
        SetNewData();
    }

    public void AddResourceTwo()
    {
        AddResourceTwo<Boards>();
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
                Destroy(wall.gameObject);
            }

            _player.SellCoints(MaxCountCountCoin);
            _statsSetup.ActiveAmaunt();
            _resourceCollector.SellCountResource<Log>(CountResourceTwo);
            _resourceCollector.SellCountResource<Boards>(MaxCountCountTwo);
            Destroy(this.gameObject);
        }
    }
}