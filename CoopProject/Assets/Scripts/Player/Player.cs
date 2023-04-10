using System;
using DefaultNamespace;
using ResourcesColection;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimatorPlayer _animator;

    private ExtractResourceService _extractResource;
    private static int _layerMask;
    private int _treeResourceCounter;
    private int _damage = 20;
    private int _coins = 0;
    private float _extractDuration = 1f;
    private float _maxExtractDuration = 1f;
    private float _radius = 1.5f;
    private Vector3 _offset = new Vector3(0, 0.3f, 0);

    public int Coins => _coins;
    public event Action SetCoinValue;

    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
        _extractResource = new ExtractResourceService(transform, _layerMask, _radius);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out ResourceSource resource))
        {
            _extractDuration -= Time.deltaTime;

            if (_extractDuration < 0)
            {
                transform.LookAt( resource.transform.position + _offset);
            }
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.24f, _layerMask))
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

    public void Extract()
    {
        _extractResource.ExtractResource(_damage);
    }

    public void SetCoinsValue(int coins)
    {
        if (coins > 0)
            _coins += coins;
        
        SetCoinValue?.Invoke();
    }

    public void SellCoints(int price)
    {
        if (price > 0 && _coins >= price)
            _coins -= price;
        
        SetCoinValue?.Invoke();
    }
}