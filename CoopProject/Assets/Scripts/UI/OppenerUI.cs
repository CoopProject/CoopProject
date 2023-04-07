using DG.Tweening;
using System.Collections;
using UnityEngine;

public class OppenerUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _timeAnimation;

    private RectTransform _rectTransform;
    private int _minScale = 0;
    private int _maxScale = 1;
    private WaitForSeconds _waitTime;
    private bool _isCorutineWork = false;

    private void OnEnable()
    {
        _waitTime = new WaitForSeconds(_timeAnimation);
        _rectTransform = _panel.GetComponent<RectTransform>();
    }

    private void OnTriggerEnter(Collider ñollider)
    {
        if (ñollider.TryGetComponent(out Player player))
            Open();
    }

    private void OnTriggerExit(Collider ñollider)
    {
        if (ñollider.TryGetComponent(out Player player))
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

        if (!_isCorutineWork)
            StartCoroutine(OnPlayedDelay());
    }

    private IEnumerator OnPlayedDelay()
    {
        yield return _waitTime;
        _panel.SetActive(false);
    }
}
