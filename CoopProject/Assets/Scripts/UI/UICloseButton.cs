using UnityEngine;
using UnityEngine.UI;

public class UICloseButton : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    private void Start() => _closeButton.onClick.AddListener(Close);
    
    private void Close() => gameObject.SetActive(false);
}