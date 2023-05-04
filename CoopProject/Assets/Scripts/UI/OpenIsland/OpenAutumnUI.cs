using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class OpenAutumnUI : OpenIslandPanel<Log, Boards>
{
    [SerializeField] private StatsSetup _statsSetup;

    private int _wallsDisabel = 0;
    private string _dataKey = "Autumn";

    public string DataKey => _dataKey;

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

    private void Update() => ActiveIsland();

    protected void AddCoin() => AddCoinsPanel();
    

    protected void AddResourceOne() => AddResourceOne<Log>();
    

    protected void AddResourceTwo() => AddResourceTwo<Boards>();
    

    protected override void ActiveIsland()
    {
        if (CountCoin == MaxCountCountCoin && CountResourceOne == MaxCountResourceOne &&
            CountResourceTwo == MaxCountResourceTwo)
        {
            foreach (var wall in _walls)
                wall.Disable();

            _wallsDisabel = 1;
            PlayerPrefs.SetInt(_dataKey, _wallsDisabel);
            _statsSetup.ActiveAmaunt();
            DisableOpenners();
        }
    }

    private void DisableOpenners()
    {
        for (int i = 0; i < _oppener.Count; i++)
        {
            _oppener[i].Close();
            _oppener[i].Unplug();
        }
    }

    public void DisableWalls()
    {
        DisableOpenners();
        _statsSetup.ActiveAmaunt();
    }
}