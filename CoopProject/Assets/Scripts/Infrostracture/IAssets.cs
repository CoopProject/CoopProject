using UnityEngine;

namespace Infrostracture
{
    public interface IAssets : IService
    {
        public GameObject CreateHero(string path,Transform at);
    }
}