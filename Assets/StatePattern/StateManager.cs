using UnityEngine;
namespace StatePattern.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class StateManager : MonoBehaviour
    {
        private IState _currentState;
        public StateLibrari.IdleState _idleState { get; private set; }
        public StateLibrari.MoveState _moveState { get; private set; }
        PlayerController _player;
        private void Awake()
        {
            _player = GetComponent<PlayerController>();
            _idleState = new StateLibrari.IdleState(_player);
            _moveState = new StateLibrari.MoveState(_player);
        }
        private void Start()
        {
            ChangeState(_idleState);
        }

        private void Update()
        {
            _currentState?.Execute();
        }

        public void ChangeState(IState newState)
        {
            if (_currentState == newState)
            {
                return;
            }
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}