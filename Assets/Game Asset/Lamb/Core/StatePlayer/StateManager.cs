using UnityEngine;
using Behavior.Player; // Thêm namespace của Behavior
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
        private void Awake()
        {
            _player = GetComponent<PlayerController>();

            _BehaviorManager = new BehaviorManager();
            _idleState = new StateLibrary.IdleState(_player);
            _moveState = new StateLibrary.MoveState(_player, _BehaviorManager);
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