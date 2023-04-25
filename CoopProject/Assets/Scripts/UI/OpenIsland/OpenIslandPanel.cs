using System;
using System.Collections.Generic;
using DefaultNamespace.Buildings.BuildingIsland;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class OpenIslandPanel<ResourceOne,ResourceTwo> : MonoBehaviour
{
    [SerializeField] protected List<OpenUIPanel> _oppener;
    [SerializeField] protected List<Wall> _walls;
    [SerializeField] protected Button _buttonClose;
    [SerializeField] protected GameData _data;
    [Header("Кнопочки для добовления")] 
    [SerializeField] protected Button _addResourceOne;
    [SerializeField] protected Button _addResourceTwo;
    [SerializeField] protected Button _addResourceFree;
    [Space]
    [SerializeField] protected int MaxCountCountCoin = 10;
    [Space]
    [SerializeField] protected int MaxCountCountOne = 15;
    [Space]
    [SerializeField] protected int MaxCountCountTwo = 20;
    
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
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountCountOne}";
        _textCounterResourceTwo.text = $"{CountResourceTwo}/{MaxCountCountTwo}";
    }

    protected void SetNewData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountCountOne}";
        _textCounterResourceTwo.text = $"{CountResourceTwo}/{MaxCountCountTwo}"; 
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

    protected void AddResourceOne<T>()
    {
        int resourceCount = _resourceCollector.GetCountList<T>();

        if (resourceCount >= MaxCountCountOne)
        {
            CountResourceOne = MaxCountCountOne;
        }
        else
        {
            CountResourceOne = resourceCount;
        }
    }

    protected void AddResourceTwo<T>()
    {
        int resourceCount = _resourceCollector.GetCountList<T>();

        if (resourceCount >= MaxCountCountTwo)
        {
            CountResourceTwo = MaxCountCountTwo;
        }
        else
        {
            CountResourceTwo = resourceCount;
        }
    }

    protected void Close() => gameObject.SetActive(false);

    protected abstract void ActiveIsland();
}
