using Infrostracture;
using UnityEngine;
using Object = System.Object;

public class LoadLevelState : IPayloadedState<int>, IExitableState
{
    private const string SpawnPointPlayer = "SpawnPointPlayer";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactory _gameFactory;
    private readonly LoadingCurtain _loadingCurtain;

    public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
    {
        _stateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _loadingCurtain = loadingCurtain;
        _gameFactory = gameFactory;
    }

    public void Enter(int payLoad)
    {
        _sceneLoader.Load(payLoad, OnLoaded);
    }
    
    private void OnLoaded()
    {
        Debug.Log(_gameFactory);
        GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(SpawnPointPlayer));
        _stateMachine.Enter<GameLoopState>();
        Camera.main.GetComponent<FollowTarget>().SetTarget(hero.transform);
    }
    
    public void Exit()
    {
    }

}