using System.Collections;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection;
using ResourcesGame.TypeResource;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class Tree : ResourceSource
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
        Occupy();
        if (_health <= 0)
        {
            Dead();
            _iDead = true;
            AddResource();
            StartCoroutine(Reset());
        }
    }

    private void AddResource()
    {
        for (int i = 0; i < _resourceAddCount; i++)
        {
            Log log = new ();
            log.SetPrice();
            _resourceCollector.AddResource<Log>(log);    
        }
        
    }

    public override void AddResourceCount(int resourceExtraction) => _resourceAddCount = resourceExtraction;
    
    private IEnumerator Reset()
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(_durationReset);
        yield return waitForSecondsRealtime;
        _iDead = false;
        _health = _maxHealth;
        _mesh.enabled = true;
        _iFree = true;
        _colliderBox.enabled = true;
    }
}