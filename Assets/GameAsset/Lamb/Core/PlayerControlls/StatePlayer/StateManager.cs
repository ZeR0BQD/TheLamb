using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Player
{
    public partial class StateManager : MonoBehaviour
    {
        private IState _currentState;
        public event System.Action<IState> OnStateChanged;

        public IPlayerPhysics _physics { get; private set; }

        private readonly Dictionary<IDStatePlayer, IState> _states = new Dictionary<IDStatePlayer, IState>();
        private IInputReader _inputReader;

        public void ChangeState(IDStatePlayer id)
        {
            if (_states.TryGetValue(id, out IState state))
            {
                ChangeState(state);
            }
            else
            {
                Debug.LogWarning($"[StateManager] Khong tim thay state voi ID: {id}");
            }
        }

        public void ChangeState(IState newState)
        {
            if (_currentState == newState) return;

            _currentState?.Exit();
            _currentState = newState;
            OnStateChanged?.Invoke(_currentState);
            _currentState?.Enter();
        }

        private void HandleDashEvent()
        {
            _currentState?.OnDashSignal();
        }

        private void Update()
        {
            _currentState?.Execute();
        }

        private void FixedUpdate()
        {
            _currentState?.FixedExecute();
        }
    }
}