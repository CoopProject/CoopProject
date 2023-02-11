using System;
using System.Collections.Generic;
using UnityEngine;

namespace HelperMashin
{
    public class HelperStateMashin : MonoBehaviour, IHelperStateMashin
    {
        [SerializeField] private MoveStateHelper _stateMove;
        
        private Dictionary<Type, IStateHelper> _States;
        private IStateHelper _lastState;

        private void Awake()
        {
            _States = new Dictionary<Type, IStateHelper>()
            {
                [typeof(MoveStateHelper)] = _stateMove,
            };
        }

        public void Enter<TState>() where TState : IStateHelper
        {
            _lastState?.Exit();
            IStateHelper state = _States[typeof(TState)];
            _lastState = state;
            state.Enter();
            Debug.Log(state);
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}