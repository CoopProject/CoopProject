using ResourcesGame.TypeResource;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ProductPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private TextMeshProUGUI _textEndCount;
    [SerializeField] private TextMeshProUGUI _levelValue;
    [SerializeField] protected Button _addResourceButton;
    [SerializeField] protected Button _addAllResourceButton;
    [SerializeField] protected Button _takeResourceBackButton;
    [SerializeField] protected Button _takeResourceComplitButton;
    [SerializeField] protected Button _buttonLevelUp;
    [SerializeField] protected Button _buttonLevelUpReward;
    [SerializeField] protected Processor _processor;

    protected ResourceCollector _resourceCollector;
    protected PlayerWallet _playerWallet;
    protected int _counter => _processor.CountTransformation;
    private int _levelNow = 1;
    private int _levelUpPrice = 100;

    private void OnEnable()
    {
        _processor.Done += ConversionComplit;
    }

    private void LateUpdate()
    {
        SetData();
    }

    private void SetData()
    {
        _textCount.text = $"{_processor.CountTransformation}";
        _textEndCount.text = $"{_processor.Completed}";
    }

    public void LevelUp()
    {
        if (_playerWallet.Coins >= _levelUpPrice && _levelNow < 5)
        {
            _processor.LevelUp();
            _playerWallet.SellCoints(_levelUpPrice);
            _levelNow++;
            _levelValue.text = $"{_levelNow}";
        }
    }

    protected void ConversionComplit()
    {
        if (_counter < 0)
        {
            _textCount.text = $"{_processor.CountTransformation}";
            _textEndCount.text = $"{_processor.Completed}";
        }
    }

    protected void SellAllResource<T>()
    {
        var countResource = _resourceCollector.GetCountList<T>();

        if (countResource != 0)
        {
            _processor.AddAll(countResource);
            _resourceCollector.SallResource<T>();
        }
    }

    protected void AddResources<T>()
    {
        int countList = _resourceCollector.GetCountList<T>();

        if (_counter <= countList && countList != 0)
        {
            _resourceCollector.SellCountResource<T>(1);
            _processor.Conversion();
            _textCount.text = $"{_processor.CountTransformation}";
            _textEndCount.text = $"{_processor.Completed}";
        }
    }
    

    protected void TakeResourceComplite<Type>(Resource resource)
    {
        for (int i = 0; i < _processor.Completed; i++)
            _resourceCollector.AddResource<Type>(resource);
    }

    protected void TakeResource<Type>(Resource resource)
    {
        if (_processor.CountTransformation > 0)
        {
            _resourceCollector.AddResource<Type>(resource);
            _processor.CancellationProcessing();
            _textCount.text = $"{_processor.CountTransformation}";
        }
    }


    protected void Reset()
    {
        if (_processor.Completed > 0)
        {
            _textCount.text = $"{_processor.CountTransformation}";
            _textEndCount.text = $"{_processor.Completed}";
            _processor.Reset();
        }
    }

    private void OnDisable() => _processor.Done -= ConversionComplit;
}