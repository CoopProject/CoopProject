using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class OpenWinterIsland : OpenIslandPanel<Stone,StoneBlocks>
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
        ActiveBreadge();
    }

    public void AddCoin()
    {
        ValidateAdd();
        SetNewData();
    }

    public void AddResourceOne()
    {
        AddResourceLog<Stone>();
        SetNewData();
    }

    public void AddResourceTwo()
    {
        AddResourceBoards<StoneBlocks>();
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
        if (CountCoin == MaxCountCountCoin && CountResourceOne == MaxCountCountOne &&
            CountResourceTwo == MaxCountCountTwo)
        {
            foreach (var wall in _walls)
            {
                wall.gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
    }
}
