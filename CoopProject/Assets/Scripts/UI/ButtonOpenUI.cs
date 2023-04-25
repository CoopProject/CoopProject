using System;
using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonOpenUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _timeAnimation;
    
    private Button _button;
    private RectTransform _rectTransform;
    private int _minScale = 0;
    private int _maxScale = 1;
    private WaitForSeconds _waitTime;
    private bool _isCoroutineWork = false;
    private bool _isOpen;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _isOpen = gameObject.activeSelf;
        _waitTime = new WaitForSeconds(_timeAnimation);
        _button.onClick.AddListener(AutoSetState);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(AutoSetState);
    }

    private void AutoSetState()
    {
        if (!_isOpen)
        {
            Open();
            return;
        }
        
        Close();
    }

    private void Open()
    {
        _panel.SetActive(true);
        _rectTransform.DOScale(_maxScale, _timeAnimation);
    }

    private void Close()
    {
        _rectTransform.DOScale(_minScale, _timeAnimation);
        
        if (!_isCoroutineWork)
            StartCoroutine(OnStartDisable());
    }

    private IEnumerator OnStartDisable()
    {
        _isCoroutineWork = true;
        yield return _waitTime;
        gameObject.SetActive(false);
        _isCoroutineWork = false;
    }
}
