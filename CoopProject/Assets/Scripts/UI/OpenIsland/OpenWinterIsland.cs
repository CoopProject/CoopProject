using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class OpenWinterIsland : OpenIslandPanel<Stone,StoneBlocks>
{
    [SerializeField] private StatsSetup _statsSetup;
    
    private int _wallsDisabel = 0;
    private string _dataKey = "Winter";
    
    public string DataKey => _dataKey;

    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void OnEnable() =>  SetStartData();
    
    private void Start()
    {
        _addResourceOne.onClick.AddListener(AddCoins);
        _addResourceTwo.onClick.AddListener(AddResourceOne);
        _addResourceFree.onClick.AddListener(AddResourceTwo);
    }

    private void Update() => ActiveIsland();
    

    private void AddCoins() => AddCoinsPanel();
    

    private void AddResourceOne() => AddResourceOne<Stone>();
    

    private void AddResourceTwo() => AddResourceTwo<StoneBlocks>();
    
    
    protected override void ActiveIsland()
    {
        if (CountCoin == MaxCountCountCoin && CountResourceOne == MaxCountResourceOne &&
            CountResourceTwo == MaxCountResourceTwo)
        {
            foreach (var wall in _walls)
                wall.gameObject.SetActive(false);
            
            _wallsDisabel = 1;
            PlayerPrefs.SetInt(_dataKey, _wallsDisabel);
            _statsSetup.ActiveWinter();
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
        _statsSetup.ActiveWinter();
        DisableOpenners();
    }
}
