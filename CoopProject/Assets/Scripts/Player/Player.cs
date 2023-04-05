using System;
using DefaultNamespace;
using ResourcesColection;
using ResourcesGame.TypeResource;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimatorPlayer _animator;

    private int _treeResourceCounter;
    private float _extractDuration = 3f;
    private static int _layerMask;
    private float _radius = 3f;
    private int _damage = 20;
    private float _maxExtractDuration = 3;
    private ExtractResourceService _extractResource;
    private int _coins = 0;
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
                Debug.Log("Аниматор должен запустить добычу");
                _animator.Extract();
                transform.LookAt( resource.transform.position + _offset);
                _extractDuration = _maxExtractDuration;
            }
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