using System;
using System.Collections.Generic;
using UnityEngine;

namespace HelperMashin
{
    [RequireComponent(typeof(MoveStateHelper))]
    [RequireComponent(typeof(ExtractResourceState))]
    public class HelperStateMashin : MonoBehaviour, IHelperStateMashin
    {
        [SerializeField] private MoveStateHelper _stateMove;
        [SerializeField] private ExtractResourceState _stateExtract;
        
        private Dictionary<Type, IStateHelper> _States;
        private IStateHelper _lastState;

        private void Awake()
        {
            _States = new Dictionary<Type, IStateHelper>()
            {
                [typeof(MoveStateHelper)] = _stateMove,
                [typeof(ExtractResourceState)] = _stateExtract,
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
            
        }
    }
}