using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HelperMashin
{
    public class HelperStateMashin : MonoBehaviour
    {
        private IState _state;
        private readonly Dictionary<Type,IState> _states;
        private IState _lastState;

        public HelperStateMashin()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(FindingState)]= new FindingState(),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _lastState.Exit();
           IState state =  _states[typeof(TState)];
           _lastState = state;
           state.Enter();
        }
    }
}