using UnityEngine;
namespace StatePattern.Player
{
    public class StateAnimManager : MonoBehaviour
    {
        private IAnimState _currentState;
        public PlayerController _player { get; private set; }
        public StateAnimLib.IdleAnimState _idleState { get; private set; }
        public StateAnimLib.RunAnimState _runState { get; private set; }
        public StateAnimLib.DashAnimState _dashState { get; private set; }
        private void Awake()
        {
            _player = GetComponent<PlayerController>();
            _idleState = new StateAnimLib.IdleAnimState(this);
            _runState = new StateAnimLib.RunAnimState(this);
            _dashState = new StateAnimLib.DashAnimState(this);
        }

        private void Start()
        {
            ChangeState(_idleState);
        }

        private void Update()
        {
            _currentState?.Execute();
        }
        public void ChangeState(IAnimState newState)
        {
            if (_currentState == newState) return;

            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}