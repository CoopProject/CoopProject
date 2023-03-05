using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection;
using UnityEngine;

public class Rock : Resource,IResourceSource
{
    private TreeKeeper _treeKeeper;
    private int _resourceValue = 15;
    private int _maxHealth = 10;
    private float _durationReset = 1f;



    public override void TakeDamage(int damage)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/RockHit");
        _health -= damage;
        
        if (_health <= 0)
        {
            Dead();
            _iDead = true;
        }
        
    }

    public object transform { get; set; }

    private void Dead()
    {
        gameObject.SetActive(false);
    }

}
