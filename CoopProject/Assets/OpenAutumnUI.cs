using System;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesGame.TypeResource;

public class OpenAutumnUI : OpenIslandPanel<Log,Boards>
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
        AddResourceLog<Log>();
        SetNewData();
    }

    public void AddResourceTwo()
    {
        AddResourceBoards<Boards>();
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

    private void AddResourceLog<Log>()
    {
        int resourceCount = _resourceCollector.GetCountList<Log>();
        
        if (resourceCount >= MaxCountCountOne)
        {
            CountResourceOne = MaxCountCountOne;
        }
        else
        {
            CountResourceOne = resourceCount;
        }
    }

    private void AddResourceBoards<Boards>()
    {
        int resourceCount = _resourceCollector.GetCountList<Boards>();
        
        if (resourceCount >= MaxCountCountTwo)
        {
            CountResourceTwo = MaxCountCountTwo;
        }else
        {
            CountResourceTwo = resourceCount;
        }
    }

    protected override void ActiveBreadge()
    {
        if (CountCoin == MaxCountCountCoin && CountResourceOne == MaxCountCountOne &&CountResourceTwo == MaxCountCountTwo )
        {
            _islandBridge.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
