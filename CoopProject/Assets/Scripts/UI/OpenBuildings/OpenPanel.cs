using TMPro;
using UnityEngine;

public class OpenPanel<T> : MonoBehaviour 
{
    [SerializeField] private Building _building;
    [SerializeField] private Tarpaulin _tarpaulin;
    [SerializeField] private TextMeshProUGUI _textCounterCoin;
    [SerializeField] private TextMeshProUGUI _textCounterResourceOne;
    [Space] 
    [SerializeField] private int MaxCountCountCoin = 10;
    [Space]
    [SerializeField] private int MaxCountResourceOne = 15;
    
    private int CountCoin = 0;
    private int CountResourceOne = 0;
    
    protected ResourceCollector _resourceCollector;
    protected Player _player;
    private T _resourceType;

    private void OnEnable() => SetStartData();
    
    protected void SetResourceType(T resource) =>  _resourceType = resource;

    public void AddCoin()
    {
        ValidateAdd();
        SetNewData();
    }

    public void AddResourceOne()
    {
        AddResourceOne<T>();
        SetNewData();
    }

    private void SetStartData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountResourceOne}";


        CountCoin = 0;
        CountResourceOne = 0;
    }

    private void SetNewData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResourceOne}/{MaxCountResourceOne}";
    }

    private void AddResourceOne<_resourceType>()
    {
        int resourceCount = _resourceCollector.GetCountList<_resourceType>();

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


    protected void ActiveBreadge<_resourceType>()
    {
        if (CountCoin == MaxCountCountCoin && CountResourceOne == MaxCountResourceOne)
        {
            _building.gameObject.SetActive(true);
            _player.SellCoints(MaxCountCountCoin);
            _resourceCollector.SellCountResource<_resourceType>(MaxCountResourceOne);
            Destroy(this.gameObject);
            Destroy(_tarpaulin.gameObject);
        }
    }
}