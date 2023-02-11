using System.Collections;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class ResourceTree : MonoBehaviour,IResource
{

    private ResourceTreeWatcher _resourceTreeWatcher;
    private int _resourceValue = 15;
    private int _health = 10;
    private int _maxHealth = 10;
    private float _durationReset = 1f;
    private bool _iDead = false;

    public bool IDead => _iDead;

    [Inject]
    private void Construct(Container container)
    {
        _resourceTreeWatcher = container.Resolve<ResourceTreeWatcher>();
    }

    private void Start()
    {
        _resourceTreeWatcher.SetTree<ResourceTree>(this);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            Dead();
            _iDead = true;
            _resourceTreeWatcher.RemoveITemList<ResourceTree>(this);
        }
        
    }

    private void Dead()
    {
        gameObject.SetActive(false);
    }
    
}