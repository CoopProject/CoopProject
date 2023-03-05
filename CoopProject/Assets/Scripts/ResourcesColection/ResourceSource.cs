using UnityEngine;

namespace ResourcesColection
{
    public abstract class ResourceSource : MonoBehaviour
    {
        public abstract void TakeDamage(int damage);
    }
}