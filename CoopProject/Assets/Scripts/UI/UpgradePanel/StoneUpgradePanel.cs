using System.Collections;
using System.Collections.Generic;
using Reflex;
using Reflex.Scripts.Attributes;
using TMPro;
using UnityEngine;

public class StoneUpgradePanel : MonoBehaviour
{
    [SerializeField] private HelpersBuildingTree helpersBuildingTree;
    [SerializeField] private TextMeshProUGUI _Level;
    [SerializeField] private TextMeshProUGUI _countHelperInstance;
    [SerializeField] private TextMeshProUGUI _textNextCountSpawnHelper;
    [SerializeField] private TextMeshProUGUI _extraction;
    [SerializeField] private TextMeshProUGUI _textValumeExtraction;
    [SerializeField] private TextMeshProUGUI _buttonPrice;
    [Range(0, 1)] [SerializeField] private float _levelUpProgres = 0;

    protected Player _player;
    private int _lvlUpPrice = 10;
    private int _levelUpPriceNext = 3;
    private float _levelUpStep = 0.2f;
    private int _extractionValue = 0;
    private int _helperBuildingLevel = 1;
    private int _nexLevelExtraction;

    [Inject]
    private void Inject(Container container) => _player = container.Resolve<Player>();

    private void Start() => SetStartData();

    private void SetStartData()
    {
        _Level.text = $"{_helperBuildingLevel}";
        _countHelperInstance.text = $"{helpersBuildingTree.Counter}";
        _extraction.text = $"{_extractionValue}";
        _textValumeExtraction.text = $"{_nexLevelExtraction = _extractionValue + 3}";
        _textNextCountSpawnHelper.text = $"{helpersBuildingTree.Counter}";
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
        _lvlUpPrice += _levelUpPriceNext;
        if (_levelUpProgres >= 0.8)
        {
            _textNextCountSpawnHelper.text = $"{helpersBuildingTree.Counter + 1}";

            if (_levelUpProgres >= 1)
            {
                helpersBuildingTree.Lvlup();
                _levelUpProgres = 0;
                _textNextCountSpawnHelper.text = $"{helpersBuildingTree.Counter + 1}";
            }
        }

        SetNewData();
    }

    private void SetNewData()
    {
        _countHelperInstance.text = $"{helpersBuildingTree.Counter}";
        _Level.text = $"{_helperBuildingLevel}";
        _extractionValue += 3;
        _extraction.text = $"{_extractionValue}";
        _textValumeExtraction.text = $"{_nexLevelExtraction = _extractionValue + 3}";
        _buttonPrice.text = $"{_lvlUpPrice}";
    }
}
