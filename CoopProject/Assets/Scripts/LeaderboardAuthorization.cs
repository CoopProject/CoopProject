#pragma warning disable

using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardAuthorization : MonoBehaviour
{
    [SerializeField] private GameObject _lockPanel;
    [SerializeField] private Button _authorizationButton;
    [SerializeField] private InitializingSDK _initializingSDK;

#if YANDEX_GAMES && UNITY_WEBGL && !UNITY_EDITOR
    
    private void OnEnable()
    {
        _initializingSDK.SDKInitialized += SetLockPanelActivity;
        _authorizationButton.onClick.AddListener(Authorize);
    }

    private void OnDisable()
    {
        _initializingSDK.SDKInitialized -= SetLockPanelActivity;
        _authorizationButton.onClick.RemoveListener(Authorize);
    }

    private void Authorize()
    {
        PlayerAccount.Authorize(onSuccessCallback: SetLockPanelActivity);
    }

    private void SetLockPanelActivity()
    {
        if (PlayerAccount.IsAuthorized)
            _lockPanel.SetActive(false);
    }
#endif
}
