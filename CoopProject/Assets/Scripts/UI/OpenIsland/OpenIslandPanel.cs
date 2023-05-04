using System.Collections.Generic;
using DefaultNamespace.Buildings.BuildingIsland;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class OpenIslandPanel<ResourceOne,ResourceTwo> : MonoBehaviour
{
    [SerializeField] protected List<OpenUIPanel> _oppener;
    [SerializeField] protected List<Wall> _walls;
    [SerializeField] protected GameData _data;
    [Header("Кнопочки для добовления")] 
    [SerializeField] protected Button _addResourceOne;
    [SerializeField] protected Button _addResourceTwo;
    [SerializeField] protected Button _addResourceFree;
    [Space]
    [SerializeField] protected int MaxCountCountCoin;
    [Space]
    [SerializeField] protected int MaxCountResourceOne;
    [Space]
    [SerializeField] protected int MaxCountResourceTwo;
    
    [Header("Счетчики ресурсов")]
    [SerializeField] private TextMeshProUGUI _textCounterCoin;
    [SerializeField] private TextMeshProUGUI _textCounterResourceOne;
    [SerializeField] private TextMeshProUGUI _textCounterResourceTwo;

    protected int CountCoin = 0;
    protected int CountResourceOne = 0;
    protected int CountResourceTwo = 0;
    
    protected ResourceCollector _resourceCollector;
    protected PlayerWallet _playerWallet;

    private void OnEnable() => SetStartData();
    
    protected void SetStartData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountResourceOne}";
        _textCounterResourceTwo.text = $"{CountResourceTwo}/{MaxCountResourceTwo}";
    }

    protected void SetNewData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountResourceOne}";
        _textCounterResourceTwo.text = $"{CountResourceTwo}/{MaxCountResourceTwo}"; 
    }
    
    protected void AddCoinsPanel()
    {
        if (CountCoin == MaxCountCountCoin)
            return;
        
        if (_playerWallet.Coins >= MaxCountCountCoin)
        {
            CountCoin = MaxCountCountCoin;
            _playerWallet.SellCoints(CountCoin);
        }
        else
        {
            if ((CountCoin+_playerWallet.Coins) > MaxCountCountCoin )
            {
                var difference = MaxCountCountCoin - CountCoin;
                CountCoin = MaxCountCountCoin;
                _playerWallet.SellCoints(difference);
            }
            else
            {
                CountCoin += _playerWallet.Coins;
                _playerWallet.SellCoints(_playerWallet.Coins);
            }
        }

        SetNewData();
    }

    protected void AddResourceOne<T>()
    {
        int resourceCount = _resourceCollector.GetCountList<T>();

        if (CountResourceOne == MaxCountResourceOne)
            return;

        if (resourceCount >= MaxCountResourceOne)
        {
            _resourceCollector.SellCountResource<T>(MaxCountResourceOne);
            CountResourceOne = MaxCountResourceOne;
        }
        else
        {
            if ((CountResourceOne + resourceCount) > MaxCountResourceOne)
            {
                var difference =  MaxCountResourceOne - CountResourceOne;
                CountResourceOne = MaxCountResourceOne;
                _resourceCollector.SellCountResource<T>(difference);
            }
            else
            {
                CountResourceOne += resourceCount;
                _resourceCollector.SellCountResource<T>(resourceCount);
            }
        }

        SetNewData();
    }

    protected void AddResourceTwo<T>()
    {
        int resourceCount = _resourceCollector.GetCountList<T>();
        
        if (CountResourceTwo == MaxCountResourceTwo)
            return;

        if (resourceCount >= MaxCountResourceTwo)
        {
            _resourceCollector.SellCountResource<T>(MaxCountResourceTwo);
            CountResourceTwo = MaxCountResourceTwo;
        }
        else
        {
            if ((CountResourceTwo + resourceCount) > MaxCountResourceTwo)
            {
                var difference = MaxCountResourceTwo - CountResourceTwo;
                CountResourceTwo = MaxCountResourceTwo;
                _resourceCollector.SellCountResource<T>(difference);
            }
            else
            {
                CountResourceTwo+= resourceCount;
                _resourceCollector.SellCountResource<T>(resourceCount);
            }
        }

        SetNewData();
    }

    protected abstract void ActiveIsland();
}
