using ResourcesGame;
using UnityEngine.UIElements.Experimental;

namespace ResourcesColection.Tree
{
    public class ResourceTree: Resource, IResource
    {
        private void Start()
        {
            PriceResource = 30;
        }

        public int PriceResource { get; set; }
    }
}