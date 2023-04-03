using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class OpenWinterIsland : OpenIslandPanel<Stone,StoneBlocks>
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
        AddResourceOne<Stone>();
        SetNewData();
    }

    public void AddResourceTwo()
    {
        AddResourceTwo<StoneBlocks>();
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
            _walls = null;
             _statsSetup.ActiveWinter();
            _player.SellCoints(MaxCountCountCoin);
            _resourceCollector.SellCountResource<Stone>(CountResourceTwo);
            _resourceCollector.SellCountResource<StoneBlocks>(MaxCountCountTwo);
            Destroy(this.gameObject);
        }
    }
}
