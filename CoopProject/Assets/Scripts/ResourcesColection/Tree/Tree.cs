using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection;
using UnityEngine;

public class Tree : ResourceSource
{
    private TreeKeeper _treeKeeper;
    private int _resourceValue = 15;
    private int _health = 10;
    private int _maxHealth = 10;
    private float _durationReset = 1f;
    private bool _iDead = false;

    public bool IDead => _iDead;

    [Inject]
    private void Construct(Container container)
    {
        _treeKeeper = container.Resolve<TreeKeeper>();
    }

    private void Start()
    {
        _treeKeeper.SetRecousrce<Tree>(this);
    }

    public override void TakeDamage(int damage)
    {
        
        FMODUnity.RuntimeManager.PlayOneShot("event:/TreeHit");
        _health -= damage;
        
        if (_health <= 0)
        {
            Dead();
            _iDead = true;
            _treeKeeper.RemoveITemList<Tree>(this);
        }
        
    }

    private void Dead()
    {
        gameObject.SetActive(false);
    }
    
}