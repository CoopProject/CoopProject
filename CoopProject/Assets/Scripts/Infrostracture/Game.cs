
public class Game
{
    public  GameStateMachine _stateMashin;

    public Game(LoadingCurtain loadingCurtain, LoadingCurtain curtain )
    {
        _stateMashin = new GameStateMachine(new SceneLoader(loadingCurtain),curtain,AllServices.Container);
    }
}
