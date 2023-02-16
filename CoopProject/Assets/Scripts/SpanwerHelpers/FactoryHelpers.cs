using UnityEngine;


public class FactoryHelpers : IFactoryHelper
{
    public T InstanceHelper<T>(T helper, Transform spawnPoint) where T : MonoBehaviour, IHelper
    {
        T ObjectHelper = GameObject.Instantiate(helper, spawnPoint.position, Quaternion.identity);
        return ObjectHelper;
    }
}