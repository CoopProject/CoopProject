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
    private int _maxHealth = 10;
    private int _health = 30;
    private float _durationReset = 10f;
    private ResourceCollector _resourceCollector;
    private int _resourceAddCount = 1;

    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
    
    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        _colliderBox = GetComponent<BoxCollider>();
    }
    
    public override void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log("Камень получил урон");
        if (_health <= 0)
        {
            Dead();
            AddResource();
            StartCoroutine(Reset());
        }
    }
    
    private void AddResource()
    {
        for (int i = 0; i < _resourceAddCount; i++)
        {
            Stone stone = new ();
            stone.SetPrice();
            _resourceCollector.AddResource<Stone>(stone);    
        }
    }
    
    public void AddResourceCount() => _resourceAddCount++;

    private IEnumerator Reset()
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(_durationReset);
        yield return waitForSecondsRealtime;
        _iDead = false;
        _health = _maxHealth;
        _mesh.enabled = true;
        _colliderBox.enabled = true;
    }
}
