using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonOpenUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _timeAnimation;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _mainButton;

    public UnityAction PanelOpen;

    private RectTransform _rectTransform;
    private WaitForSeconds _waitTime;
    private int _minScale = 0;
    private int _maxScale = 1;
    private bool _isCoroutineWork = false;
    private bool _isOpen = false;
    private bool _theObjectMustBeDisabled = false;

    private void OnEnable()
    {
        _rectTransform = _panel.GetComponent<RectTransform>();
        _waitTime = new WaitForSeconds(_timeAnimation);
        _mainButton.onClick.AddListener(AutoSetState);
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _mainButton.onClick.RemoveListener(AutoSetState);
        _closeButton.onClick.RemoveListener(Close);
    }

    public void AutoSetState()
    {
        if (!_isOpen)
        {
            Open();
            return;
        }
        
        Close();
    }

    public void Open()
    {
        _panel.SetActive(true);
        _rectTransform.DOScale(_maxScale, _timeAnimation);
        _isOpen = true;
    }

    public void Close()
    {
        _rectTransform.DOScale(_minScale, _timeAnimation);
        _isOpen = false;

        if (!_isCoroutineWork)
            StartCoroutine(OnStartDisable());
    }

    private IEnumerator OnStartDisable()
    {
        _isCoroutineWork = true;
        yield return _waitTime;
        _panel.SetActive(false);
        _isCoroutineWork = false;
        
        if (_theObjectMustBeDisabled)
            gameObject.SetActive(false);
    }
}
