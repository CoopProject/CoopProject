using DefaultNamespace;
using ResourcesColection;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private AnimatorPlayer _animator;
    [SerializeField] private PlayerMovement _playerMovement;

    private ExtractResourceService _extractResource;
    private static int _layerMask;
    private int _damage = 20;
    private float _extractDuration = 1f;
    private float _rotationDuration = 1f;
    private float _rotationMaxDuration = 1f;
    private float _maxExtractDuration = 1f;
    private float _radius = 1.5f;
    
    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
        _extractResource = new ExtractResourceService(transform, _layerMask, _radius);
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out ResourceSource resource))
        {
            _rotationDuration -= Time.deltaTime;
            _extractDuration -= Time.deltaTime;

            if (_rotationDuration < 0 && _playerMovement.Imove == false)
            {
                var direction = resource.transform.position - transform.position;
                direction.y = 0;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
                _rotationDuration = _rotationMaxDuration;
            }
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.10f, _layerMask))
        {
            if (_extractDuration < 0)
            {
                _animator.Extract();
                _extractDuration = _maxExtractDuration;
            }
        }
        else
        {
            _animator.StopExtract();
        }
    }

    public void Extract() => _extractResource.ExtractResource(_damage);
}