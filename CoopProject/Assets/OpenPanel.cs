using ResourcesGame.TypeResource;
using TMPro;
using UnityEngine;

public abstract class OpenPanel : MonoBehaviour
{
    [SerializeField] protected Building _building;
    [SerializeField] protected Tarpaulin _tarpaulin;

    [SerializeField] private TextMeshProUGUI _textCounterCoin;
    [SerializeField] private TextMeshProUGUI _textCounterResourceOne;
    [Space]
    [SerializeField] protected int MaxCountCountCoin = 10;
    [Space]
    [SerializeField] protected int MaxCountResourceOne = 15;
    
    protected int CountCoin = 0;
    protected int CountResourceOne = 0;
    
    protected ResourceCollector _resourceCollector;
    protected Player _player;
    
    protected void SetStartData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountResourceOne}";


        CountCoin = 0;
        CountResourceOne = 0;
    }

    protected void SetNewData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountResourceOne}";
    }
    
    protected void AddResourceOne<T>()
    {
        int resourceCount = _resourceCollector.GetCountList<T>();

        if (resourceCount >= MaxCountResourceOne)
        {
            CountResourceOne = MaxCountResourceOne;
        }
        else
        {
            CountResourceOne = resourceCount;
        }
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

    protected abstract void ActiveBreadge();
}