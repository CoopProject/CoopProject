using Agava.YandexGames;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ProductPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private TextMeshProUGUI _textEndCount;
    [SerializeField] private TextMeshProUGUI _levelValue;
    [SerializeField] private GameObject _levelMaxPanel;
    [SerializeField] private GameData _data;
    [SerializeField] protected Button _addResourceButton;
    [SerializeField] protected Button _addAllResourceButton;
    [SerializeField] protected Button _takeResourceBackButton;
    [SerializeField] protected Button _takeResourceComplitButton;
    [SerializeField] protected Button _buttonLevelUp;
    [SerializeField] protected Button _buttonLevelUpReward;
    [SerializeField] protected Processor _processor;
    [SerializeField] private string _keyData = "";

    protected ResourceCollector _resourceCollector;
    protected PlayerWallet _playerWallet;
    protected int _counter => _processor.CountTransformation;
    private int _levelNow = 1;
    private int _levelUpPrice = 100;
    private int _maxLevel = 5;

    private void OnEnable()
    {
        _processor.Done += ConversionComplit;
        LoadData();
        CheckMaxLevel();
    }

    private void LateUpdate() => SetData();
    
    private void SetData()
    {
        _textCount.text = $"{_processor.CountTransformation}";
        _textEndCount.text = $"{_processor.Completed}";
    }

    public void LevelUp()
    {
        if (_playerWallet.Coins >= _levelUpPrice && _levelNow < _maxLevel)
        {
            _processor.LevelUp();
            _playerWallet.SellCoints(_levelUpPrice);
            _levelNow++;
            _levelValue.text = $"{_levelNow}";
            _data.Save(_keyData,_levelNow);
            CheckMaxLevel();
        }
    }

    public void LevelUpReward()
    {
        if (_playerWallet.Coins >= _levelUpPrice && _levelNow < _maxLevel)
        {
            VideoAd.Show(GamePause.OnGamePauseActive,null,GamePause.OffGamePauseActive);
            _processor.LevelUpReward();
            _playerWallet.SellCoints(_levelUpPrice);
            _levelNow += 2;
            _levelValue.text = $"{_levelNow}";
            CheckMaxLevel();
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
            _resourceCollector.SellResource<T>();
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
    
    protected void TakeResourceComplite<Type>()
    {
        for (int i = 0; i < _processor.Completed; i++)
            _resourceCollector.AddResource<Type>();
    }

    protected void TakeResource<Type>()
    {
        if (_processor.CountTransformation > 0)
        {
            _resourceCollector.AddResource<Type>();
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

    private void LoadData()=> _levelNow =  _data.Load(_keyData);

    private void CheckMaxLevel()
    {
        _levelValue.text = $"{_levelNow}";
        if (_levelNow == 5)
        {
            _levelMaxPanel.gameObject.SetActive(true);
            _buttonLevelUp.gameObject.SetActive(false);
            _buttonLevelUpReward.gameObject.SetActive(false);
        }
    }
}