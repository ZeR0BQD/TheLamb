using UnityEngine;
using Behavior.Player;
using Unity.VisualScripting;

namespace StatePattern.Player
{
    public class StateManager : MonoBehaviour
    {
        private IState _currentState;
        public StateLibrary.IdleState _idleState { get; private set; }
        public StateLibrary.DashState _dashState { get; private set; }
        public StateLibrary.RunState _moveState { get; private set; }
        public PlayerController _player { get; private set; }

        private void Awake()
        {
            var playerActions = new BehaviorLibrary();

            _player = GetComponent<PlayerController>();
            _idleState = new StateLibrary.IdleState(this);
            _moveState = new StateLibrary.RunState(playerActions, this);
            _dashState = new StateLibrary.DashState(playerActions, this);
        }

        private void Start()
        {
            ChangeState(_idleState);
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
            _currentState?.Enter();
        }
    }
}