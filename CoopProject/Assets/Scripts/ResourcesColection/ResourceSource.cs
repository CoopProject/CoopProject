using UnityEngine;

namespace ResourcesColection
{
    public abstract class ResourceSource : MonoBehaviour,IResourceSource
    {
         protected MeshRenderer _mesh;
         protected BoxCollider _colliderBox;
         protected Transform _transform;
        
        protected bool _iDead = false;
        protected bool _iFree = true;
        protected bool _used;
        public bool IDead => _iDead;
        public bool Used => _used;
        public bool Free => _iFree;
        public Transform Transform => _transform;
        
                

        public abstract void TakeDamage(int damage);
        
        public void Occupy() => _iFree = false;

        public void ToFree() => _iFree = true;
        
        protected void Dead()
        {
            _mesh.enabled = false;
            _colliderBox.enabled = false;
            _iFree = false;
        }

        public abstract void AddResourceCount(int extraction);
    }
}