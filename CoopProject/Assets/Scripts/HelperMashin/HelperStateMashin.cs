using System;
using System.Collections.Generic;
using UnityEngine;

namespace HelperMashin
{
    public class HelperStateMashin : MonoBehaviour, IHelperStateMashin
    {
        
        private Dictionary<Type, IStateHelper> _States;
        private IStateHelper _lastState;

        public HelperStateMashin()
        {
            _States = new Dictionary<Type, IStateHelper>()
            {
                [typeof(FindingStateHelper)] = new FindingStateHelper(this),
                [typeof(MoveStateHelper)] = new MoveStateHelper(this),
            };
        }
        
        public void Enter<TState>() where TState : IStateHelper
        {
            _lastState?.Exit();
            IStateHelper state = _States[typeof(TState)];
            _lastState = state;
            state.Enter();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}