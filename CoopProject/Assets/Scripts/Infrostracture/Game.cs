using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public  GameStateMashin _stateMashin;

    public Game(ICoroutineRunner coroutineRunner)
    {
        _stateMashin = new GameStateMashin(new SceneLoader(coroutineRunner));
    }
}
