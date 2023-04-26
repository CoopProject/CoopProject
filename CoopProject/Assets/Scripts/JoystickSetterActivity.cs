using UnityEngine;
using Agava.YandexGames;
using DeviceType = Agava.YandexGames.DeviceType;

public class JoystickSetterActivity : MonoBehaviour
{
    [SerializeField] private InitializingSDK _initializingSDK;
    [SerializeField] private GameObject _joystick;
    
    private void Awake()
    {
        _initializingSDK.SDKInitialized += SetActive;
    }

    private void OnDisable()
    {
        _initializingSDK.SDKInitialized -= SetActive;
    }

    private void SetActive()
    {
        Debug.Log("МЕТОД ЗАПУЩЕН");
        Debug.Log("ДЕВАЙС  " + Device.Type);

        if (Device.Type == DeviceType.Mobile || Device.Type == DeviceType.Tablet)
        {
            Debug.Log("ДЖОЙСТИК АКТИВИРОВАН");
            _joystick.SetActive((true));
        }
    }
}
