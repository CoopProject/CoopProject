using UnityEngine;

namespace ResourcesColection
{
    public abstract class Resource : MonoBehaviour
    {
        protected int _health = 30;
        protected bool _iDead = false;

        public bool IDead => _iDead;
        public abstract void TakeDamage(int damage);
    }
}