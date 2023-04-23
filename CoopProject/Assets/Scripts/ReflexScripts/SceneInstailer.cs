using Reflex;
using Reflex.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneInstailer : Installer
{
    [SerializeField] private ResourceCollector _resourceCollector;
    [SerializeField] private PlayerWallet _playerWallet;

    public override void InstallBindings(Container container)
    {
        container.BindInstanceAs(_resourceCollector);
        container.BindInstanceAs(_playerWallet);
    }
}
