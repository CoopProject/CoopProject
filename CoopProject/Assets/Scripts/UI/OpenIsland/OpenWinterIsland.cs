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
        _playerWallet = container.Resolve<PlayerWallet>();
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
        if (_playerWallet.Coins > MaxCountCountCoin)
        {
            CountCoin = MaxCountCountCoin;
            return true;
        }

        CountCoin = _playerWallet.Coins;
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
            _playerWallet.SellCoints(MaxCountCountCoin);
            _resourceCollector.SellCountResource<Stone>(CountResourceTwo);
            _resourceCollector.SellCountResource<StoneBlocks>(MaxCountCountTwo);
            Destroy(gameObject);
        }
    }
}
