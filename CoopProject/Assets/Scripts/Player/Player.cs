using DefaultNamespace;
using ResourcesColection;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimatorPlayer _animator;

    private int _treeResourceCounter;
    private float _extractDuration = 3f;
    private static int _layerMask;
    private float _radius = 0.3f;
    private int _damage = 1;
    private float _maxExtractDuration = 3;
    private ExtractResourceService _extractResource;
    
    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Resource");
        _extractResource = new ExtractResourceService(transform, _layerMask,_radius);
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
        _extractResource.ExtractResource(_damage);
    }
}