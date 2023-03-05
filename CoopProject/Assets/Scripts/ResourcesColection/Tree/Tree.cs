using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection;
using UnityEngine;

public class Tree : Resource, IResourceSource
{
    private int _resourceValue = 15;
    private int _maxHealth = 10;
    private float _durationReset = 1f;
    

    public override void TakeDamage(int damage)
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/TreeHit");
        _health -= damage;
        
        if (_health <= 0)
        {
            Dead();
            _iDead = true;
        }
    }
    
    private void Dead()
    {
        gameObject.SetActive(false);
    }
    
}