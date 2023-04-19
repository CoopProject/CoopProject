using System.Collections.Generic;
using Agava.YandexGames;
using DefaultNamespace.Buildings;
using DefaultNamespace.UI.UpgradePanel;
using ResourcesColection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradePanelUI<T> : MonoBehaviour where T : ResourceSource
{
    [SerializeField] private HelperBuildng<T> _helpersBuilding;
    [SerializeField] private GameObject _levelMaxPanel;
    [SerializeField] private TextMeshProUGUI _levelUpNow;
    [SerializeField] private TextMeshProUGUI _countHelperInstance;
    [SerializeField] private TextMeshProUGUI _nextCountSpawnHelper;
    [SerializeField] private TextMeshProUGUI _extraction;
    [SerializeField] private TextMeshProUGUI _valumeExtraction;
    [SerializeField] private Button _buttonLvlUp;
    [SerializeField] private Button _buttonLvlUpReward;
    [SerializeField] private TextMeshProUGUI _buttonPrice;
    [SerializeField] private List<LevelUpData> _levelUps;

    protected PlayerWallet _playerWallet;
    
    private int _levelNow = 0;

    public List<LevelUpData> LevelUps => _levelUps;
    public int LevelNow => _levelNow;

    private void Start()
    {
        SetData();
        SetNexData();
        _helpersBuilding.Lvlup(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        _buttonLvlUp.onClick.AddListener(LevelUp);
        _buttonLvlUpReward.onClick.AddListener(LevelUpReward);
    }

    private void LevelUp()
    {
        if (_playerWallet.Coins >= LevelUps[_levelNow].LevelUpPrice && _levelNow < LevelUps.Count - 1)
        {
            _playerWallet.SellCoints(LevelUps[_levelNow].LevelUpPrice);
            _levelNow++;
            SetData();
            SetNexData();
            _helpersBuilding.Lvlup(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        }
    }

    private void LevelUpReward()
    {
        if (_playerWallet.Coins >= LevelUps[_levelNow].LevelUpPrice && _levelNow < LevelUps.Count - 1)
        {

            if (_levelNow < LevelUps.Count - 2)
                _levelNow += 2;
            
            else
                _levelNow++;
            
            _playerWallet.SellCoints(LevelUps[_levelNow].LevelUpPrice);
            SetData();
            SetNexData();
            _helpersBuilding.Lvlup(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
            VideoAd.Show();
        }
    }

    private void SetData()
    {
        _buttonPrice.text = $"{LevelUps[_levelNow].LevelUpPrice}";
        _levelUpNow.text = $"{_levelNow}";
        _extraction.text = $"{LevelUps[_levelNow].ExtractedResources}";
        _countHelperInstance.text = $"{LevelUps[_levelNow].InstanceHelpers}";
    }

    private void SetNexData()
    {
        if (_levelNow + 1 < LevelUps.Count)
        {
            _valumeExtraction.text = $"{LevelUps[_levelNow + 1].ExtractedResources}";
            _nextCountSpawnHelper.text = $"{LevelUps[_levelNow + 1].InstanceHelpers}";
        }
        else
        {
            _levelMaxPanel.gameObject.SetActive(true);
            _valumeExtraction.text = $"{LevelUps[_levelNow].ExtractedResources}";
            _nextCountSpawnHelper.text = $"{LevelUps[_levelNow].InstanceHelpers}";
            _buttonLvlUp.gameObject.SetActive(false);
            _buttonLvlUpReward.gameObject.SetActive(false);
        }
    }
}