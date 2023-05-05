using Agava.YandexGames;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ProductPanel : MonoBehaviour
{
    [SerializeField] protected Button _addResourceButton;
    [SerializeField] protected Button _addAllResourceButton;
    [SerializeField] protected Button _takeResourceBackButton;
    [SerializeField] protected Button _takeResourceComplitButton;
    [SerializeField] protected Button _buttonLevelUp;
    [SerializeField] protected Button _buttonLevelUpReward;
    [SerializeField] protected Processor _processor;
    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private TextMeshProUGUI _textEndCount;
    [SerializeField] private TextMeshProUGUI _levelValue;
    [SerializeField] private TMP_Text _buttonPrice;
    [SerializeField] private TMP_Text _rewardButtonPrice;
    [SerializeField] private GameObject _levelMaxPanel;
    [SerializeField] private string _keyData = "";
    [SerializeField] private int _levelUpPrice = 100;
    [SerializeField] private int _priceValueChange = 20;

    protected ResourceCollector _resourceCollector;
    protected PlayerWallet _playerWallet;
    protected int _counter => _processor.CountTransformation;
    private int _levelNow = 1;
    private int _maxLevel = 5;

    private void OnEnable()
    {
        _processor.Done += ConversionComplit;
        LoadData();
        CheckMaxLevel();
        UpdateUI();
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
            _levelUpPrice += _priceValueChange;
            _levelNow++;
            UpdateUI();
            PlayerPrefs.SetInt(_keyData,_levelNow);
            CheckMaxLevel();
        }
    }

    public void LevelUpReward()
    {
        if (_playerWallet.Coins >= _levelUpPrice / 2 && _levelNow < _maxLevel)
        {
            VideoAd.Show(GamePause.OnGamePauseActive,null,GamePause.OffGamePauseActive);
            _processor.LevelUpReward();
            _playerWallet.SellCoints(_levelUpPrice / 2);
            _levelUpPrice += _priceValueChange;
            _levelNow += 2;
            UpdateUI();
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

        if (countList != 0)
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

    private void LoadData()=> _levelNow =  PlayerPrefs.GetInt(_keyData);

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

    private void UpdateUI()
    {
        _buttonPrice.text = _levelUpPrice.ToString();
        _rewardButtonPrice.text = (_levelUpPrice / 2).ToString();
        _levelValue.text = $"{_levelNow}";
    }
}