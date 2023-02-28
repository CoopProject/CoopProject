using HelperMashin;
using Reflex;
using Reflex.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneInstailer : Installer
{
    [SerializeField] private TreeKeeper treeKeeper;

    public override void InstallBindings(Container container)
    {
        container.BindInstanceAs(treeKeeper);
    }
}
