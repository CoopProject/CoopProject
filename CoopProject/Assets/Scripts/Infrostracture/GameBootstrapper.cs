using UnityEngine;

public class GameBootstrapper : MonoBehaviour,LoadingCurtain
{
    private Game _game;
    public LoadingCurtain Curtain;
    private void Awake()
    {
        _game = new Game(this,Curtain);
        _game._stateMashin.Enter<BootstrapState>();
        DontDestroyOnLoad(this);
    }
}