using System.Collections;
using ResourcesColection;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class Tree : Resource, IResourceSource
{
    private int _maxHealth = 30;
    private int _health = 30;
    private float _durationReset = 8f;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        _colliderBox = GetComponent<BoxCollider>();
    }


    public override void TakeDamage(int damage)
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/TreeHit");
        _health -= damage;
        
        if (_health <= 0)
        {
            Dead();
            _iDead = true;
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