using System;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimatorPlayer _animator;

    private int _treeResourceCounter;
    private float _extractDuration = 3f;
    private static int _layerMask;
    private float _radius = 0.3f;
    private int _damage = 20;
    private float _maxExtractDuration = 3;
    private ExtractResourceService _extractResource;
    private int _coins = 0;

    public int Coins => _coins;
    public event Action SetCoinValue;

    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
        _extractResource = new ExtractResourceService(transform, _layerMask, _radius);
    }

    public void FixedUpdate()
    {
        RaycastHit hit;
        _extractDuration -= Time.deltaTime;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.25f, _layerMask))
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