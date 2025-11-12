using UnityEngine;
using Behavior.Player;
using Unity.VisualScripting;

namespace StatePattern.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class StateManager : MonoBehaviour
    {
        private IState _currentState;
        public StateLibrary.IdleState _idleState { get; private set; }
        public StateLibrary.DashState _dashState { get; private set; }
        public StateLibrary.MoveState _moveState { get; private set; }
        public PlayerController _player { get; private set; }
        private BehaviorManager _behaviorManager;

        private void Awake()
        {
            _behaviorManager = new BehaviorManager();
            _player = GetComponent<PlayerController>();
            _idleState = new StateLibrary.IdleState(this);
            _moveState = new StateLibrary.MoveState(_behaviorManager, this);
            _dashState = new StateLibrary.DashState(_behaviorManager, this);
        }

        private void Start()
        {
            ChangeState(_idleState);
        }

        private void Update()
        {

            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     Debug.Log(Input.GetKeyDown(KeyCode.Space));
            //     ChangeState(_dashState);
            // }


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