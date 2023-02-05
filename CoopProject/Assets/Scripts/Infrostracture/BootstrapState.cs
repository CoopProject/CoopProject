using System;

public class BootstrapState : IState
{
    private readonly GameStateMashin _stateMashin;
    private SceneLoader _scenLoad;
    private readonly  int _scenNumber = 0;
    public BootstrapState(GameStateMashin stateMashin,SceneLoader scenLoad)
    {
        _stateMashin = stateMashin;
        _scenLoad = scenLoad;
    }

    public void Enter()
    {
        RegisterServices();
        _scenLoad.Load(_scenNumber,EnterLoadLevel);
    }

    private void EnterLoadLevel()
    {
        _stateMashin.Enter<LoadLevelState>();
    }

    private void RegisterServices()
    {
        
    }

    public void Exit()
    {
       
    }
}