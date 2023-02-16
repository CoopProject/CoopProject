using UnityEngine;

public interface IFactoryHelper
{
    T InstanceHelper<T>(T helper ,Transform spawnPoint) where T : MonoBehaviour,IHelper;
}