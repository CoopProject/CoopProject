using System;
using TMPro;
using UnityEngine;

public abstract class OpenIslandPanel<ResourceOne,ResourceTwo> : MonoBehaviour
{
    [SerializeField] protected IslandBridge _islandBridge;
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

    protected abstract void ActiveBreadge();

}
