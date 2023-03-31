using UnityEngine;

namespace ResourcesGame.TypeResource
{
    public abstract class Resource : MonoBehaviour
    {
        public int Price { get; protected set; } = 0;
    }
}