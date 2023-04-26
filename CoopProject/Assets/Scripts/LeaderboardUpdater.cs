#pragma warning disable

using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUpdater : MonoBehaviour
{
    [SerializeField] private List<LeaderboardPlayerView> _leaderboardViews;
    [SerializeField] private InitializingSDK _initializingSDK;

    private string _leaderboardName = "lb";
    private int _currentViewIndex = 0;
    private int _maxLenghtLeaderboard = 5;

#if YANDEX_GAMES && UNITY_WEBGL && !UNITY_EDITOR

    private void OnEnable()
    {
        _initializingSDK.SDKInitialized += UpdateScorePanel;
    }

    private void OnDisable()
    {
        _initializingSDK.SDKInitialized -= UpdateScorePanel;
    }

    public void UpdateScorePanel()
    {
        Leaderboard.GetEntries(_leaderboardName, (result) =>
        {
            foreach (var entry in result.entries)
            {
                _currentViewIndex++;

                if (_currentViewIndex > _maxLenghtLeaderboard)
                    return;

                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";

                _leaderboardViews[_currentViewIndex - 1].Render(name, entry.score);
            }
        });
    }

#endif
}
