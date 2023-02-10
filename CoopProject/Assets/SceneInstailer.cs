using Reflex;
using Reflex.Scripts;
using UnityEngine;

public class SceneInstailer : Installer
{
    [SerializeField] private ResourceTreeWatcher _resourceTreeWatcher;
    
    public override void InstallBindings(Container container)
    {
        container.BindInstanceAs(_resourceTreeWatcher);
    }
}
