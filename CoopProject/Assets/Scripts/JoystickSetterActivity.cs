using UnityEngine;
using Agava.YandexGames;
using DeviceType = Agava.YandexGames.DeviceType;

public class JoystickSetterActivity : MonoBehaviour
{
    [SerializeField] private InitializingSDK _initializingSDK;
    [SerializeField] private GameObject _joystick;
    
    private void Awake() => _initializingSDK.SDKInitialized += SetActive;
    

    private void OnDisable() => _initializingSDK.SDKInitialized -= SetActive;
    

    private void SetActive()
    {
        if (Device.Type == DeviceType.Mobile || Device.Type == DeviceType.Tablet)
            _joystick.SetActive((true));
        
    }
}
