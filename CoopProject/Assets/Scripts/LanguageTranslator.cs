using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

public class LanguageTranslator : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;
    [SerializeField] private InitializingSDK _initializingSDK;
    
    private void OnEnable()
    {
        _initializingSDK.SDKInitialized += SetLaunguage;
    }

    private void OnDisable()
    {
        _initializingSDK.SDKInitialized -= SetLaunguage;
    }

    private void SetLaunguage()
    {
        _leanLocalization.SetCurrentLanguage(YandexGamesSdk.Environment.i18n.lang);
    }
}
