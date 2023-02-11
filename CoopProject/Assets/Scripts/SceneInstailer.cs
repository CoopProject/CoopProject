using HelperMashin;
using Reflex;
using Reflex.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneInstailer : Installer
{
    [FormerlySerializedAs("_resourceTreeWatcher")] [SerializeField] private TreeKeeper treeKeeper;
    [FormerlySerializedAs("_helperStateMashin")] [SerializeField] private HelperStateMachine helperStateMachine;
    
    public override void InstallBindings(Container container)
    {
        container.BindInstanceAs(treeKeeper);
        container.BindInstanceAs(helperStateMachine);
    }
}
