using Agava.YandexGames;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SetterJoystickPosition : MonoBehaviour
{
    [SerializeField] private RectTransform _canvas;
    [SerializeField] private RectTransform _joystickPanel;
    [SerializeField] private Image _joystickRidged;
    [SerializeField] private Image _joystickOutline;
    
    private PlayerInputActions _inputActions;
    private Vector2 _inputPosition;
    private Vector2 _canvasPosition;
    private bool _isFirstSet = true;

    private void OnEnable()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Player.MouseGetPosition.performed += OnSetPosition;
        _inputActions.Player.TouchGetPosition.performed += OnSetPosition;
        _inputActions.Player.TouchActivateJoystick.started += OnSetActive;
        _inputActions.Player.TouchActivateJoystick.canceled += OnSetActive;
    }

    private void OnDisable()
    {
        _inputActions.Player.MouseGetPosition.performed -= OnSetPosition;
        _inputActions.Player.TouchGetPosition.performed -= OnSetPosition;
        _inputActions.Player.TouchActivateJoystick.started -= OnSetActive;
        _inputActions.Player.TouchActivateJoystick.canceled -= OnSetActive;
    }
    private void OnSetPosition(InputAction.CallbackContext context)
    {
        if (_isFirstSet)
        {
            CalculatePosition(context);
            _joystickPanel.anchoredPosition = _canvasPosition;
        } 
    }

    private void OnSetActive(InputAction.CallbackContext context)
    {
        _joystickRidged.enabled = (!_joystickRidged.enabled);
        _joystickOutline.enabled = (!_joystickOutline.enabled); 
        _isFirstSet = !_isFirstSet;
    }

    private void CalculatePosition(InputAction.CallbackContext context)
    {
        _inputPosition = context.ReadValue<Vector2>();
        float scaleXCoefficient = _canvas.sizeDelta.x / Screen.width;
        float scaleYCoefficient = _canvas.sizeDelta.y / Screen.height;
        _canvasPosition = new Vector2(_inputPosition.x * scaleXCoefficient, _inputPosition.y * scaleYCoefficient);
    }
}

