
public class Game
{
    public  GameStateMashin _stateMashin;

    public Game(ICoroutineRunner coroutineRunner)
    {
        _stateMashin = new GameStateMashin(new SceneLoader(coroutineRunner));
    }
}
