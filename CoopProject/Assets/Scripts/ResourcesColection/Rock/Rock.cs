using System.Collections;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection;
using ResourcesGame.TypeResource;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class Rock : ResourceSource,IResourceSource
{
    private ResourceCollector _resourceCollector;
    private int _maxHealth = 30;
    private int _health = 30;
    private float _durationReset = 8f;
    private int _resourceAddCount = 1;
    
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
    
    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        _colliderBox = GetComponent<BoxCollider>();
        _transform = transform;
    }

    public override void TakeDamage(int damage)
    {
        _health -= damage;
        _used = true;
        if (_health <= 0)
        {
            Dead();
            _iDead = true;
            AddResource();
            StartCoroutine(ResetResource());
        }
    }

    private void AddResource()
    {
        for (int i = 0; i < _resourceAddCount; i++)
        {
            _resourceCollector.AddResource<Stone>();    
        }
        
    }

    public override void AddResourceCount(int resourceExtraction) => _resourceAddCount = resourceExtraction;
    
    private IEnumerator ResetResource()
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(_durationReset);
        yield return waitForSecondsRealtime;
        _iDead = false;
        _health = _maxHealth;
        _used = false;
        _mesh.enabled = true;
        ToFree();
        _colliderBox.enabled = true;
    }
}
