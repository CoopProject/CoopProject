using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class OpenWinterIsland : OpenIslandPanel<Stone,StoneBlocks>
{
    [SerializeField] private StatsSetup _statsSetup;

    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void OnEnable() =>  SetStartData();
    
    private void Start()
    {
        _addResourceOne.onClick.AddListener(AddCoin);
        _addResourceTwo.onClick.AddListener(AddResourceOne);
        _addResourceFree.onClick.AddListener(AddResourceTwo);
    }

    private void Update() => ActiveIsland();
    

    private void AddCoin()
    {
        ValidateAdd();
        SetNewData();
    }

    private void AddResourceOne()
    {
        AddResourceOne<Stone>();
        SetNewData();
    }

    private void AddResourceTwo()
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
                wall.gameObject.SetActive(false);

            _playerWallet.SellCoints(MaxCountCountCoin);
            _resourceCollector.SellCountResource<Stone>(CountResourceOne);
            _resourceCollector.SellCountResource<StoneBlocks>(CountResourceTwo);
            _statsSetup.ActiveWinter();
            _oppener.Close();
            _oppener.Unplug();
        }
    }
}
