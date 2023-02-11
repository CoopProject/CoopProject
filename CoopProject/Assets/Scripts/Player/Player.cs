using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimatorPlayer _animator;

    private int _treeResourceCounter;
    private float _extractDuration = 1f;
    private static int _layerMask;
    private Collider[] _hits = new Collider[1];
    private float _radius = 0.3f;
    private int _damage = 1;
    
    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
    }


    public void FixedUpdate()
    {
        _extractDuration -= Time.deltaTime;
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, _layerMask))
        {
            if (_extractDuration < 0 && Hit() > 0)
            {
                _hits[0].GetComponent<ResourceTree>().TakeDamage(_damage);
                Extract();
            }
            else 
                _animator.StopExtract();
        }
        else
        {
            _animator.StopExtract();
        }
    }
    
    

    private int Hit()
    {
      return  Physics.OverlapSphereNonAlloc(transform.position + transform.forward, _radius, _hits, _layerMask);
    }

    private void Extract()
    {
        _animator.Extract();
    }
}