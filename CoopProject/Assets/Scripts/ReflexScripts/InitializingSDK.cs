#pragma warning disable

using System;
using System.Collections;
using Agava.YandexGames;
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
}
