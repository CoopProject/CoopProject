using ResourcesColection;
using UnityEngine;

namespace DefaultNamespace
{
    public class ExtractResourceService
    {
        private Transform _transform;
        private Collider[] _hits = new Collider[1];
        private int _layerMask;
        private float _radius;

        public ExtractResourceService(Transform transform,int layerMask,float radius)
        {
            _transform = transform;
            _layerMask = layerMask;
            _radius = radius;
        }

        public void ExtractResource(int _damageEnemy)
        {
            if (Hit() > 0)
            {
                _hits[0].GetComponent<IResourceSource>().TakeDamage(_damageEnemy);
            }
        }
        private int Hit()
        {
            return  Physics.OverlapSphereNonAlloc(_transform.position + _transform.forward, _radius, _hits, _layerMask);
        }
    }
}