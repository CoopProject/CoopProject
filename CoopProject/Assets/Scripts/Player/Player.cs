using ResourcesColection;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimatorPlayer _animator;

    private int _treeResourceCounter;
    private float _extractDuration = 3f;
    private static int _layerMask;
    private Collider[] _hits = new Collider[1];
    private float _radius = 0.3f;
    private int _damage = 1;
    private float _maxExtractDuration = 3;
    
    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
    }


    public void FixedUpdate()
    {
        RaycastHit hit;
        _extractDuration -= Time.deltaTime;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.25f, _layerMask))
        {
            if (_extractDuration < 0)
            {
                _animator.Extract();
                _extractDuration = _maxExtractDuration;
            }
        }
        else
        {
            _animator.StopExtract();
        }
    }
    

    public void Extract()
    {
        if (Hit() > 0)
        {
            _hits[0].GetComponent<IResourceSource>().TakeDamage(_damage);
        }
    }
    private int Hit()
    {
        return  Physics.OverlapSphereNonAlloc(transform.position + transform.forward, _radius, _hits, _layerMask);
    }
}