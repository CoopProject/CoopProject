using UnityEngine;

namespace ResourcesColection
{
    public abstract class Resource : MonoBehaviour,IResourceSource
    {
        protected bool _iDead = false;
        public bool IDead => _iDead;
        public abstract void TakeDamage(int damage);
    }
}