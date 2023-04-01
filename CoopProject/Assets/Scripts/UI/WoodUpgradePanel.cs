using Reflex;
using Reflex.Scripts.Attributes;
using TMPro;
using UnityEngine;

public class WoodUpgradePanel : MonoBehaviour
{
    [SerializeField] private HelpersBuilding _helpersBuilding;
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private TextMeshProUGUI _textHelperInstance;
    [SerializeField] private TextMeshProUGUI _textExtraction;
    [SerializeField] private TextMeshProUGUI _textNextCountSpawnHelper;
    [SerializeField] private TextMeshProUGUI _textValumeExtraction;
    [SerializeField] private TextMeshProUGUI _buttonPrice;
    [Range(0, 1)][SerializeField] private float _levelUpProgres = 1;

    private Player _player;
    private int _lvlUpPrice = 10;
    private int _levelUpPriceNext = 3;
    private float _levelUpStep = 0.2f;
    private int _extractionValue = 0;
    private int _nexLevelExtraction;
    private int _helperBuildingLevel = 1;
    
    
    [Inject]
    private void Inject(Container container)
    {
        _player = container.Resolve<Player>();
    }

    private void Start()
    {
        SetStartData();
    }

    private void SetStartData()
    {
        _textLevel.text = $"{_helperBuildingLevel}";
        _textHelperInstance.text = $"{_helpersBuilding.Counter}";
        _textExtraction.text = $"{_extractionValue}";
        _textValumeExtraction.text = $"{_nexLevelExtraction = _extractionValue + 3}";
        _textNextCountSpawnHelper.text = $"{_helpersBuilding.Counter}";
        _buttonPrice.text = $"{_lvlUpPrice}";
    }

    public void BuyLevel()
    {
        if (_player.Coins >= _lvlUpPrice)
        {
            _helperBuildingLevel++;
            LevelUp();
            _player.SellCoints(_lvlUpPrice);
        }
    }

    private void LevelUp()
    {
        _levelUpProgres += _levelUpStep;
        if (_levelUpProgres >= 0.6 )
        {
            _textNextCountSpawnHelper.text = $"{_helpersBuilding.Counter + 1}";
            
            if (_levelUpProgres >= 1)
            {
                _helpersBuilding.Lvlup();
                _levelUpProgres = 0;
                _textNextCountSpawnHelper.text = $"{_helpersBuilding.Counter + 1}";
            }
        }
            
        SetNewData();
    }

    private void SetNewData()
    {
        _textHelperInstance.text = $"{_helpersBuilding.Counter}";
        _textLevel.text = $"{_helperBuildingLevel}";
        _extractionValue += 3;
        _textExtraction.text = $"{_extractionValue}";
        _textValumeExtraction.text = $"{_nexLevelExtraction = _extractionValue + 3}";
    }
}
