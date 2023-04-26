using UnityEngine;
using Agava.YandexGames;
using DeviceType = Agava.YandexGames.DeviceType;

public class JoystickSetterActivity : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;
    
    private void OnEnable()
    {
        if (Device.Type == DeviceType.Mobile || Device.Type == DeviceType.Tablet)
            _joystick.SetActive((true));
    }
}
