using UnityEngine;

public class SetterComponentsActivity : MonoBehaviour
{
    [SerializeField] private CameraFollowTarget _cameraFollow;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _learningPanel;
    [SerializeField] private GameObject _joystick;
    
    public void EnableComponents() 
    {
        _cameraFollow.enabled = true;
        _playerMovement.enabled = true;
        _learningPanel.SetActive(false);
        _joystick.SetActive(true);
    }
}
