using Reflex;
using Reflex.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneInstailer : Installer
{
    [SerializeField] private TreeKeeper treeKeeper;
    [SerializeField] private ResourceCollector _resourceCollector;

    public override void InstallBindings(Container container)
    {
        container.BindInstanceAs(treeKeeper);
        container.BindInstanceAs(_resourceCollector);
    }
}
