using HelperMashin;
using Reflex;
using Reflex.Scripts;
using UnityEngine;

public class SceneInstailer : Installer
{
    [SerializeField] private ResourceTreeWatcher _resourceTreeWatcher;
    [SerializeField] private HelperStateMashin _helperStateMashin;
    
    public override void InstallBindings(Container container)
    {
        container.BindInstanceAs(_resourceTreeWatcher);
        container.BindInstanceAs(_helperStateMashin);
    }
}
