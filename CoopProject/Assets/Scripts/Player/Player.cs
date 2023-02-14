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
    
    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
    }


    public void FixedUpdate()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, _layerMask))
        {
            Hit();
        }
        else
        {
            _animator.StopExtract();
        }
    }
    
    

    private int Hit()
    { 
        _animator.Extract();
      return  Physics.OverlapSphereNonAlloc(transform.position + transform.forward, _radius, _hits, _layerMask);
    }

    public void Extract()
    {
        if (Hit() > 0)
            _hits[0].GetComponent<Tree>().TakeDamage(_damage);
        
        
    }
}