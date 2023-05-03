using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;
using UnityEngine;

public class OpenMagickIsland : OpenIslandPanel<Iron, IronIngots>
{
    [SerializeField] private StatsSetup _statsSetup;

    private bool _wallsDisabel = false;
    private string _dataKey = "Magick";
    public string DataKey => _dataKey;

    [Inject]
    private void Inject(Container container)
    {
        _resourceCollector = container.Resolve<ResourceCollector>();
        _playerWallet = container.Resolve<PlayerWallet>();
    }

    private void OnEnable() => SetStartData();

    private void Start()
    {
        _addResourceOne.onClick.AddListener(AddCoin);
        _addResourceTwo.onClick.AddListener(AddResourceOne);
        _addResourceFree.onClick.AddListener(AddResourceTwo);
    }

    private void Update() => ActiveIsland();
    
    private void AddCoin() => AddCoinsPanel();
    
    private void AddResourceOne() => AddResourceOne<Iron>();
    
    private void AddResourceTwo() => AddResourceTwo<IronIngots>();
    
    protected override void ActiveIsland()
    {
        if (CountCoin == MaxCountCountCoin && CountResourceOne == MaxCountResourceOne &&
            CountResourceTwo == MaxCountResourceTwo)
        {
            foreach (var wall in _walls)
                wall.gameObject.SetActive(false);

            _wallsDisabel = true;
            _data.SaveObject(_dataKey, _wallsDisabel);
            _statsSetup.ActiveMagickIsland();
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
        _statsSetup.ActiveMagickIsland();
        DisableOpenners();
    }
}