using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFolowForTarget : MonoBehaviour
{
    [SerializeField] private Transform _inputTarget;
    [SerializeField] private float _speedFollow;
    [SerializeField] private float _cameraAxisZOffset;

    private Camera _camera;
    private Tweener _tween;
    private Vector3 _lastPosition;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _tween = _camera.transform.DOMove(SetTargetPosition(), _speedFollow).SetEase(Ease.Linear).SetSpeedBased().SetAutoKill(false);
        _lastPosition = _inputTarget.position;
    }

    private void LateUpdate()
    {
        if (_lastPosition != _inputTarget.position)
        {
            _tween.ChangeEndValue(SetTargetPosition(), true).Restart();
            _lastPosition = _camera.transform.position;
        }
    }

    private Vector3 SetTargetPosition()
    {
        return new Vector3(_inputTarget.position.x, _inputTarget.position.y, _inputTarget.position.z + _cameraAxisZOffset);
    }
}
