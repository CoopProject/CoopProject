using System;

public class LoadLevelState : IPayloadedState<int>,IExitableState
{
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public LoadLevelState(GameStateMachine stateMashin, SceneLoader coroutineRunner)
    {
        _stateMachine = stateMashin;
        _sceneLoader = coroutineRunner;
    }

    public void Enter(int payLoad)
    {
     _sceneLoader.Load(payLoad);  
    }

    public void Exit()
    {
        
    }
}