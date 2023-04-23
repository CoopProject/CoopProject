using DefaultNamespace.MVP.MVPShop.Viues;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel<T> : MonoBehaviour
{
    [Header("Кнопки")] 
    [SerializeField] protected Button _addResourceOne;
    [SerializeField] protected Button _addResourceTwo;
    [SerializeField] private OppenerUI _oppener;
    [SerializeField] private Building _building;
    [SerializeField] private Tarpaulin<T> _tarpaulin;
    [SerializeField] private TextMeshProUGUI _textCounterCoin;
    [SerializeField] private TextMeshProUGUI _textCounterResourceOne;
    [SerializeField] private StatsView _statsView;
    [SerializeField] protected GameData _data;
    [Space] 
    [SerializeField] private int MaxCountCountCoin = 10;
    [Space] 
    [SerializeField] private int MaxCountResourceOne = 15;

    protected bool _objectActive = false;
    protected RectTransform _rectTransform;
    protected ResourceCollector _resourceCollector;
    protected PlayerWallet _playerWallet;
    protected string KeyData = "";

    private int CountCoin = 0;
    private int CountResourceOne = 0;
    private int _minScale = 0;
    private T _resourceType;


    private void OnEnable() => SetStartData();

    protected void SetResourceType(T resource) => _resourceType = resource;

    protected void AddCoin()
    {
        if (ValidateAdd())
        {
            _playerWallet.SellCoints(CountCoin);
            SetNewData();
        }
        else
        {
            SetNewData();
        }
    }

    protected void AddResourceOne()
    {
        AddResourceOne<T>();
        SetNewData();
    }

    protected void SetStartData()
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

    private void AddResourceOne<ResourceInGame>()
    {
        int resourceCount = _resourceCollector.GetCountList<ResourceInGame>();

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
        if (_playerWallet.Coins > MaxCountCountCoin)
        {
            CountCoin = MaxCountCountCoin;
            return true;
        }

        CountCoin = _playerWallet.Coins;
        return false;
    }


    protected void ActiveBreadge<_resourceType>()
    {
        if (CountCoin == MaxCountCountCoin && CountResourceOne == MaxCountResourceOne)
        {
            _objectActive = true;
            _tarpaulin.ActiveObject();
            _data.SaveObject(KeyData,_objectActive);
            _building.gameObject.SetActive(true);
            _resourceCollector.SellCountResource<_resourceType>(MaxCountResourceOne);
            _statsView.gameObject.SetActive(true);
            _tarpaulin.Delete();
            _oppener.Close();
            _oppener.Unplug();
        }
    }

    public void ObjectActive()
    {
        _building.gameObject.SetActive(true);
        _statsView.gameObject.SetActive(true);
        _tarpaulin.Delete();
        _oppener.Close();
        _oppener.Unplug();
    }
}