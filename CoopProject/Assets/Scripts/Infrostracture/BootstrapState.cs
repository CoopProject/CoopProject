using System;

public class BootstrapState : IState
{
    private readonly GameStateMachine _stateMachine;
    private SceneLoader _sceneLoader;
    private readonly  int _scenNumber = 1;
    public BootstrapState(GameStateMachine stateMashin,SceneLoader scenLoad)
    {
        _stateMachine = stateMashin;
        _sceneLoader = scenLoad;
    }

    public void Enter()
    {
        RegisterServices();
        _sceneLoader.Load(0, onLoaded: EnterLoadLevel);
    }

    private void EnterLoadLevel()
    {
        _stateMachine.Enter<LoadLevelState,int>(_scenNumber);
    }

    private void RegisterServices()
    {
        
    }

    public void Exit()
    {
       
    }
}