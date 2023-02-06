using System;
using Infrostracture;

public class BootstrapState : IState
{
    private readonly GameStateMachine _stateMachine;
    private SceneLoader _sceneLoader;
    private readonly  int _scenNumber = 1;
    private readonly AllServices _services;
    
    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _services = services;

        RegisterServices();
    }

    public void Enter()
    {
        _sceneLoader.Load(_scenNumber, onLoaded: EnterLoadLevel);
    }

    public void Exit()
    {
    }

    private void RegisterServices()
    {
        _services.RegisterSingle<IAssets>(new AssetProvider());
        _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
    }

    private void EnterLoadLevel() =>
        _stateMachine.Enter<LoadLevelState,int>(1);
}