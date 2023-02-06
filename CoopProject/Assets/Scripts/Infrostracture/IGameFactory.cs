using UnityEngine;

namespace Infrostracture
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
    }
}