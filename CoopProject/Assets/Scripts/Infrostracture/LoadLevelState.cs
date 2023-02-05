using UnityEngine;
using Object = System.Object;

public class LoadLevelState : IPayloadedState<int>, IExitableState
{
    private const string SpawnPointPlayer = "SpawnPointPlayer";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public LoadLevelState(GameStateMachine stateMashin, SceneLoader coroutineRunner)
    {
        _stateMachine = stateMashin;
        _sceneLoader = coroutineRunner;
    }

    public void Enter(int payLoad)
    {
        _sceneLoader.Load(payLoad, OnLoaded);
    }

    public void Exit()
    {
    }

    private void OnLoaded()
    {
        var InitialPoint = GameObject.FindWithTag(SpawnPointPlayer);
        Debug.Log(InitialPoint);
        GameObject hero = Instantiate("Player", InitialPoint.transform.position);
    }

    private static GameObject Instantiate(string path, Vector3 at)
    {
        var prefab = Resources.Load<GameObject>(path);
        return GameObject.Instantiate(prefab);
    }
}