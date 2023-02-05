using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateMashin
{
    private readonly Dictionary<Type, IState> _states;
    private IState _activeState;

    public GameStateMashin()
    {
        _states = new Dictionary<Type, IState>();
    }
    
    
    public void Enter<TState>() where TState : IState
    {
        _activeState?.Exit();
        IState state = _states[typeof(TState)];
        state.Enter();
    }
}