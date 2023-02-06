using UnityEngine;
using UnityEngine.UI;

namespace Infrostracture
{
    public class AssetProvider : IAssets
    {
        public GameObject CreateHero(string path, Transform at)
        {
            return GameObject.Instantiate(Resources.Load<GameObject>(path),at.position,Quaternion.identity);
        }
    }
}