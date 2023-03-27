using UnityEngine;

namespace ResourcesColection
{
    public abstract class ResourceSource : MonoBehaviour,IResourceSource
    {
         protected MeshRenderer _mesh;
         protected BoxCollider _colliderBox;
        
        protected bool _iDead = false;
        public bool IDead => _iDead;
        public abstract void TakeDamage(int damage);
        
        protected void Dead()
        {
            _mesh.enabled = false;
            _colliderBox.enabled = false;
        }
    }
}