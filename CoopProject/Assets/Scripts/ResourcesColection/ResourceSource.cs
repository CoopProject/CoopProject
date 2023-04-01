using UnityEngine;

namespace ResourcesColection
{
    public abstract class ResourceSource : MonoBehaviour,IResourceSource
    {
         protected MeshRenderer _mesh;
         protected BoxCollider _colliderBox;
        
        protected bool _iDead = false;
        protected bool _iCanBeMined = true;
        public bool IDead => _iDead;
        public bool ICanBeMined => _iCanBeMined;
        
        

        public abstract void TakeDamage(int damage);
        
        public void PrivateResource()
        {
            _iCanBeMined = false;
        }
        
        protected void Dead()
        {
            _mesh.enabled = false;
            _colliderBox.enabled = false;
            _iCanBeMined = false;
        }
    }
}