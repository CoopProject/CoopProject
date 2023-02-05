using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateMashin
{
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMashin(SceneLoader sceneLoader)
    {
        _states = new Dictionary<Type, IState>()
        {
            [typeof(BootstrapState)] = new BootstrapState(this,sceneLoader),
            [typeof(BootstrapState)] = new LoadLevelState(this,sceneLoader)
        };
    }
    
    public void Enter<TState>() where TState : IState
    {
        _activeState?.Exit();
        IState state = _states[typeof(TState)];
        state.Enter();
    }
    
    public void Enter<TState,TPayLoad>(TPayLoad payLoad) where TState : IState
    {
        _activeState?.Exit();
        IState state = _states[typeof(TState)];
        state.Enter(playLoad);
    }


    private TState GetState<TState>() where TState : class, IExitableState
    {
        return _states[typeof(TState)] as TState;
    }
        
}