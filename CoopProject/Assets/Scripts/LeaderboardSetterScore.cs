#pragma warning disable

using Agava.YandexGames;
using UnityEngine;

public class LeaderboardSetterScore : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    private int _totalMonetCollected = 0;

#if YANDEX_GAMES && UNITY_WEBGL && !UNITY_EDITOR

    private void OnEnable()
    {
        LoadData();
        _playerWallet.OnPlayerScoreUpdated += UpdateCounter;
    }

    private void OnDisable()
    {
        _playerWallet.OnPlayerScoreUpdated -= UpdateCounter;
    }

    private void UpdateCounter(int value)
    {
        _totalMonetCollected += value;
        Leaderboard.SetScore("lb", _totalMonetCollected);
        SaveData();
    }
    
    private void SaveData() => PlayerPrefs.SetInt("TotalMonetCollected",_totalMonetCollected);
    
    private void LoadData() => _totalMonetCollected = PlayerPrefs.GetInt("TotalMonetCollected",0);

#endif
}
