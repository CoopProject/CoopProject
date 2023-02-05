using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour,ICoroutineRunner
{
    private Game _game;
    private void Awake()
    {
        _game = new Game(this);
        _game._stateMashin.Enter<BootstrapState>();
        DontDestroyOnLoad(this);
    }
}