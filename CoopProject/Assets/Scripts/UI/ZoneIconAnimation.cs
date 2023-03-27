using DG.Tweening;
using UnityEngine;

public class ZoneIconAnimation : MonoBehaviour
{
    private float _maxYAxis = 0.8f;
    private float _minYAxis = 0.6f;
    private float _time = 1.0f;

    private void OnEnable()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveY(_maxYAxis, _time).SetEase(Ease.Linear));
        sequence.Append(transform.DOLocalMoveY(_minYAxis, _time).SetEase(Ease.Linear));
        sequence.SetLoops(-1);
    }
}
