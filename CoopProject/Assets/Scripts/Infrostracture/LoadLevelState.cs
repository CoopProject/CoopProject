using System;

public class LoadLevelState : IState
{
    private readonly GameStateMashin _stateMashin;
    private readonly SceneLoader _sceneLoader;

    public LoadLevelState(GameStateMashin stateMashin, SceneLoader coroutineRunner)
    {
        _stateMashin = stateMashin;
        _sceneLoader = coroutineRunner;
    }

    public void Enter()
    {
        _sceneLoader.Load(1);
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }
}