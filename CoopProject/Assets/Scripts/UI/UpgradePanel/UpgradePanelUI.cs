using System.Collections.Generic;
using Agava.YandexGames;
using DefaultNamespace;
using DefaultNamespace.UI.UpgradePanel;
using ResourcesColection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradePanelUI<T> : MonoBehaviour where T : ResourceSource
{
    [SerializeField] protected Button _buttonLvlUp;
    [SerializeField] protected Button _buttonLvlUpReward;
    [SerializeField] protected GameData _data;
    [SerializeField] protected HelpersBuilding<T> _helpersBuilding;
    [SerializeField] private GameObject _levelMaxPanel;
    [SerializeField] private TextMeshProUGUI _levelUpNow;
    [SerializeField] private TextMeshProUGUI _countHelperInstance;
    [SerializeField] private TextMeshProUGUI _nextCountSpawnHelper;
    [SerializeField] private TextMeshProUGUI _extraction;
    [SerializeField] private TextMeshProUGUI _valumeExtraction;
    [SerializeField] private TextMeshProUGUI _buttonPrice;
    [SerializeField] private TextMeshProUGUI _buttonPriceReward;
    [SerializeField] private List<LevelUpData> _levelUps;

    protected PlayerWallet _playerWallet;
    protected int _levelNow = 0;
    public List<LevelUpData> LevelUps => _levelUps;
    public int LevelelNow => _levelNow;

    protected void LevelUp()
    {
        if (_playerWallet.Coins >= LevelUps[_levelNow].LevelUpPrice && _levelNow < LevelUps.Count - 1)
        {
            _levelNow++;
            _playerWallet.SellCoints(LevelUps[_levelNow].LevelUpPrice);
            SetData();
            SetNexData();
            _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
        }
    }

    protected void ShowReward() => LevelUpReward();

    protected void LevelUpReward()
    {
        if (_playerWallet.Coins >= LevelUps[_levelNow].LevelUpReward && _levelNow < LevelUps.Count - 1)
        {
            _playerWallet.SellCoints(LevelUps[_levelNow].LevelUpReward);
            SetData();
            SetNexData();
            _helpersBuilding.LevelUp(LevelUps[_levelNow].InstanceHelpers, LevelUps[_levelNow].ExtractedResources);
            VideoAd.Show(GamePause.OnGamePauseActive, null, GamePause.OffGamePauseActive);
        }
    }

    protected void SetData()
    {
        _buttonPrice.text = $"{LevelUps[_levelNow].LevelUpPrice}";
        _buttonPriceReward.text = $"{LevelUps[_levelNow].LevelUpReward}";
        _levelUpNow.text = $"{_levelNow}";
        _extraction.text = $"{LevelUps[_levelNow].ExtractedResources}";
        _countHelperInstance.text = $"{LevelUps[_levelNow].InstanceHelpers}";
    }

    protected void SetNexData()
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