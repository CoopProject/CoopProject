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
    
    [Inject]
    private void Inject(Container container) => _resourceCollector = container.Resolve<ResourceCollector>();
    
    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        _colliderBox = GetComponent<BoxCollider>();
    }


    public override void TakeDamage(int damage)
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/HitTree");
        _health -= damage;
        
        if (_health <= 0)
        {
            Dead();
            _iDead = true;
           Resource resourceSource = Instantiate(gameObject).GetComponent<Log>() ;
           _resourceCollector.AddResource<Log>(resourceSource);
            StartCoroutine(Reset());
        }
    }
    
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