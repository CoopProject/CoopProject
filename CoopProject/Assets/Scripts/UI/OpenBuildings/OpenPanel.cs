using DefaultNamespace.MVP.MVPShop.Viues;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel<T> : MonoBehaviour
{
    [Header("Кнопки")]
    [SerializeField] protected Button _addResourceOne;
    [SerializeField] protected Button _addResourceTwo;
    [SerializeField] protected GameData _data;
    [SerializeField] private OpenUIPanel _oppener;
    [SerializeField] private Building _building;
    [SerializeField] private Tarpaulin<T> _tarpaulin;
    [SerializeField] private TextMeshProUGUI _textCounterCoin;
    [SerializeField] private TextMeshProUGUI _textCounterResourceOne;
    [SerializeField] private StatsView _statsView;
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
    private int CountResource = 0;
    private T _resourceType;
    
    private void OnEnable() => SetNewData();

    protected void SetResourceType(T resource) => _resourceType = resource;

    protected void AddCoin()
    {
        if (CountCoin == MaxCountCountCoin)
            return;
        
        if (_playerWallet.Coins >= MaxCountCountCoin)
        {
            CountCoin = MaxCountCountCoin;
            _playerWallet.SellCoints(CountCoin);
            SetNewData();
        }
        else
        {
            if ((CountCoin+_playerWallet.Coins) > MaxCountCountCoin )
            {
                var difference = MaxCountCountCoin - CountCoin;
                CountCoin = MaxCountCountCoin;
                _playerWallet.SellCoints(difference);
                SetNewData();
            }
            else
            {
                CountCoin += _playerWallet.Coins;
                _playerWallet.SellCoints(_playerWallet.Coins);
                SetNewData();
            }
        }
    }

    protected void AddResourceTwo()
    {
        AddResourceTwo<T>();
        SetNewData();
    }

    protected void SetStartData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResource}/{MaxCountResourceOne}";
    }

    private void SetNewData()
    {
        _textCounterCoin.text = $"{CountCoin}/{MaxCountCountCoin}";
        _textCounterResourceOne.text = $"{CountResource}/{MaxCountResourceOne}";
    }

    private void AddResourceTwo<_resourceType>()
    {
        int resourceCount = _resourceCollector.GetCountList<_resourceType>();

        if (CountResource == MaxCountResourceOne)
            return;

        if (resourceCount >= MaxCountResourceOne)
        {
            _resourceCollector.SellCountResource<_resourceType>(MaxCountResourceOne);
            CountResource = MaxCountResourceOne;
        }
        else
        {
            if ((CountResource + resourceCount) > MaxCountResourceOne)
            {
                var difference =  MaxCountResourceOne - CountResource;
                CountResource = MaxCountResourceOne;
                _resourceCollector.SellCountResource<_resourceType>(difference);
                SetNewData();
            }
           else
           {
               CountResource += resourceCount;
               _resourceCollector.SellCountResource<_resourceType>(resourceCount);
               SetNewData();
           }
        }
    }

    protected void ActiveBreadge()
    {
        if (CountCoin == MaxCountCountCoin && CountResource == MaxCountResourceOne)
        {
            _objectActive = true;
            _tarpaulin.ActiveObject();
            _data.SaveObject(KeyData, _objectActive);
            _building.gameObject.SetActive(true);
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