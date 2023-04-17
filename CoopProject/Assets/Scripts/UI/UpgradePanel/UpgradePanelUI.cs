using System.Collections.Generic;
using DefaultNamespace.Buildings;
using DefaultNamespace.UI.UpgradePanel;
using ResourcesColection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradePanelUI<T> : MonoBehaviour where T : ResourceSource
{
    [SerializeField] private HelperBuildng<T> _helpersBuilding;
    [SerializeField] private GameObject _maxLevelPanel;
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private TextMeshProUGUI _levelUpNow;
    [SerializeField] private TextMeshProUGUI _countHelperInstance;
    [SerializeField] private TextMeshProUGUI _nextCountSpawnHelper;
    [SerializeField] private TextMeshProUGUI _extraction;
    [SerializeField] private TextMeshProUGUI _valumeExtraction;
    [SerializeField] private Button _buttonLvlUp;
    [SerializeField] private TextMeshProUGUI _buttonPrice;
    [SerializeField] private List<LevelUpData> _levelUps;

    protected PlayerWallet _playerWallet;
    private int _levelNow = 0;

    private void Start()
    {
        SetData();
        SetNexData();
        _buttonLvlUp.onClick.AddListener(LevelUp);
    }

    private void LevelUp()
    {
        if (_playerWallet.Coins >= _levelUps[_levelNow].LevelUpPrice && _levelNow < _levelUps.Count - 1)
        {
            _playerWallet.SellCoints(_levelUps[_levelNow].LevelUpPrice);
            _levelNow++;
            SetData();
            SetNexData();
            _helpersBuilding.Lvlup(_levelUps[_levelNow].InstanceHelpers, _levelUps[_levelNow].ExtractedResources);
        }
    }

    private void SetData()
    {
        _buttonPrice.text = $"{_levelUps[_levelNow].LevelUpPrice}";
        _levelUpNow.text = $"{_levelNow}";
        _extraction.text = $"{_levelUps[_levelNow].ExtractedResources}";
        _countHelperInstance.text = $"{_levelUps[_levelNow].InstanceHelpers}";
    }

    private void SetNexData()
    {
        if (_levelNow + 1 < _levelUps.Count)
        {
            _valumeExtraction.text = $"{_levelUps[_levelNow + 1].ExtractedResources}";
            _nextCountSpawnHelper.text = $"{_levelUps[_levelNow + 1].InstanceHelpers}";
            _maxLevelPanel.gameObject.SetActive(false);
            _levelPanel.gameObject.SetActive(true);
        }
        else
        {
            _maxLevelPanel.gameObject.SetActive(true);
            _levelPanel.gameObject.SetActive(false);
            _valumeExtraction.text = $"{_levelUps[_levelNow].ExtractedResources}";
            _nextCountSpawnHelper.text = $"{_levelUps[_levelNow].InstanceHelpers}";
        }
    }
}