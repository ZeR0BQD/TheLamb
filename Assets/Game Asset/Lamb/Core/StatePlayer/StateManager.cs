using UnityEngine;
using Behavior.Player;

namespace StatePattern.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class StateManager : MonoBehaviour
    {
        private IState _currentState;
        public StateLibrary.IdleState _idleState { get; private set; }
        public StateLibrary.MoveState _moveState { get; private set; }
        private PlayerController _player;
        private BehaviorManager _BehaviorManager;
        public Vector2 MoveInput { get; private set; }

        private void Awake()
        {
            _BehaviorManager = new BehaviorManager();
            _player = GetComponent<PlayerController>();
            _idleState = new StateLibrary.IdleState(this);
            _moveState = new StateLibrary.MoveState(_player, _BehaviorManager, this);
        }

        private void Start()
        {
            ChangeState(_idleState);
        }

        private void Update()
        {

            MoveInput = _player.moveInput;
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