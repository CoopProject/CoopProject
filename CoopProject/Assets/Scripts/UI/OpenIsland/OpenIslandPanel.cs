using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class OpenIslandPanel<ResourceOne,ResourceTwo> : MonoBehaviour
{
    [SerializeField] protected List<Wall> _walls;
    [Header("Счетчики ресурсов")]
    [SerializeField] private TextMeshProUGUI _textCounterCoin;
    [SerializeField] private TextMeshProUGUI _textCounterResourceOne;
    [SerializeField] private TextMeshProUGUI _textCounterResourceTwo;
    [Space]
    [SerializeField] protected int MaxCountCountCoin = 10;
    [Space]
    [SerializeField] protected int MaxCountCountOne = 15;
    [Space]
    [SerializeField] protected int MaxCountCountTwo = 20;

    protected int CountCoin = 0;
    protected int CountResourceOne = 0;
    protected int CountResourceTwo = 0;
    
    protected ResourceCollector _resourceCollector;
    protected Player _player;

    protected void SetStartData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountCountOne}";
        _textCounterResourceTwo.text = $"{CountResourceTwo}/{MaxCountCountTwo}";

        CountCoin = 0;
        CountResourceOne = 0;
        CountResourceTwo = 0;
    }

    protected void SetNewData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountCountOne}";
        _textCounterResourceTwo.text = $"{CountResourceTwo}/{MaxCountCountTwo}"; 
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

    protected abstract void ActiveBreadge();

}
