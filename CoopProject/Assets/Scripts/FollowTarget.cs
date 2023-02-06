using UnityEngine;


public class FollowTarget : MonoBehaviour
{ 
    [SerializeField] private Vector3 _offSet;
    [SerializeField] private Transform _target;
    private float _magnitude = 6f;

    private void Update()
    {
        if (_target == null)
            return;
            transform.position = Vector3.Lerp(transform.position, _target.transform.position + _offSet, Time.deltaTime * _magnitude);
    }
    
    public void SetTarget(Transform target) =>_target = target;
}
