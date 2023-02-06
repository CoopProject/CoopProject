using UnityEngine;

namespace Infrostracture
{
    public interface IAssetProvider : IAssets
    {
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path);
    }
}