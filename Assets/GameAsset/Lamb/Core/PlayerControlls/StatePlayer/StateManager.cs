using Behavior.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace StatePattern.Player
{
    public class StateManager : MonoBehaviour
    {
        private IState _currentState;
        public event System.Action<IState> OnStateChanged;
        public StateLibrary.IdleState _idleState { get; private set; }
        public StateLibrary.DashState _dashState { get; private set; }
        public StateLibrary.RunState _moveState { get; private set; }
        public IPlayerPhysics _physics { get; private set; }

        private BehaviorLibrary _playerActions;
        private IInputReader _inputReader;

        public void Initialize(IInputReader inputReader, IPlayerPhysics physics)
        {
            _physics = physics;
            _inputReader = inputReader;

            if (_inputReader != null)
            {
                _inputReader.OnDashEvent += HandleDashEvent;
            }

            _playerActions = new BehaviorLibrary(inputReader, _physics);
            _idleState = new StateLibrary.IdleState(this, _inputReader);
            _moveState = new StateLibrary.RunState(_playerActions, this, _inputReader);
            _dashState = new StateLibrary.DashState(_playerActions, this, _inputReader);
            ChangeState(_idleState);
        }

        private void OnDestroy()
        {
            if (_inputReader != null)
            {
                _inputReader.OnDashEvent -= HandleDashEvent;
            }
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

        public void ChangeState(IState newState)
        {
            if (_currentState == newState) return;

            _currentState?.Exit();
            _currentState = newState;
            OnStateChanged?.Invoke(_currentState);
            _currentState?.Enter();
        }
    }
}