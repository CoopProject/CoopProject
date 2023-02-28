using ResourcesColection;
using UnityEngine;

namespace ResourcesGame
{
    public class Resource : MonoBehaviour,IResource
    {
        protected int PriceResource;

        public int Price => PriceResource;
    }
}