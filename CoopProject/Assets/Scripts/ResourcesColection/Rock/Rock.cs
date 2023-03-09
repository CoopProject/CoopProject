using System.Collections;
using Reflex;
using Reflex.Scripts.Attributes;
using ResourcesColection;
using UnityEngine;

public class Rock : Resource,IResourceSource
{
    private int _resourceValue = 15;
    private int _maxHealth = 10;
    private int _health = 30;
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
