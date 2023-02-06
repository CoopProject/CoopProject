using UnityEngine;

namespace Infrostracture
{
    public class GameFactory : IGameFactory
    {
        private const string HeroPath = "Player/Player";
        
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at)
        {
            return _assets.CreateHero(HeroPath,at.transform);
        }
    }
}