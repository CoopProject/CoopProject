#pragma warning disable

using System.Collections;
using Agava.YandexGames;
/*using DungeonGames.VKGames;*/
using UnityEngine;
using UnityEngine.Events;

public class InitializingSDK : MonoBehaviour
{
    public UnityAction SDKInitialized;

#if YANDEX_GAMES && UNITY_WEBGL && !UNITY_EDITOR

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();
        SDKInitialized.Invoke();
    }

#endif

#if VK_GAMES && UNITY_WEBGL && !UNITY_EDITOR

    /*private void Awake()
    {
        StartCoroutine(InitializeSDK());
    }*/

    private IEnumerator Start()
    {
        yield return VKGamesSdk.Initialize(onSuccessCallback: OnSDKInitilized);
        SDKInitialized.Invoke();  
    }

    private void OnSDKInitilized()
    {
        Debug.Log("VK_SDK_Initialize_DONE!");
        Debug.Log(VKGamesSdk.Initialized);
    }

#endif
}
