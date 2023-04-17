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
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void OnEnable()
    {
        SetStartData();
    }

    private void Start()
    {
        _addResourceOne.onClick.AddListener(AddCoin);
        _addResourceTwo.onClick.AddListener(AddResourceOne);
        _addResourceFree.onClick.AddListener(AddResourceTwo);
    }

    private void Update()
    {
        ActiveIsland();
    }

    protected void AddCoin()
    {
        ValidateAdd();
        SetNewData();
    }

    protected void AddResourceOne()
    {
        AddResourceOne<Log>();
        SetNewData();
    }

    protected void AddResourceTwo()
    {
        AddResourceTwo<Boards>();
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
            _resourceCollector.SellCountResource<Log>(CountResourceOne);
            _resourceCollector.SellCountResource<Boards>(CountResourceTwo);
            _statsSetup.ActiveAmaunt();
            _oppener.Close();
            _oppener.Unplug();
        }
    }
}