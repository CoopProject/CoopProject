using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Tree : MonoBehaviour,IExtracting
{
   [SerializeField] private AudioSource _soundHit;
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

    public void TakeDamage(int damage)
    {
        _soundHit.Play();
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