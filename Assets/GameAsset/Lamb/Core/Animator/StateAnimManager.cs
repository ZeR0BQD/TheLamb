using UnityEngine;
namespace StatePattern.Player
{
    public class StateAnimManager : MonoBehaviour
    {
        private IAnimState _currentState;
        public IPlayerPhysics _physics { get; private set; }
        public Animator _animator { get; private set; }
        public IInputReader _inputReader { get; private set; }
        public StateAnimLib.IdleAnimState _idleState { get; private set; }
        public StateAnimLib.RunAnimState _runState { get; private set; }
        public StateAnimLib.DashAnimState _dashState { get; private set; }
        
        private StateManager _stateManager;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Initialize(IInputReader inputReader, IPlayerPhysics physics, StateManager stateManager)
        {
            _inputReader = inputReader;
            _physics = physics;
            _stateManager = stateManager;

            // Đăng ký lắng nghe sự kiện chuyển state từ Logic
            if (_stateManager != null)
            {
                _stateManager.OnStateChanged += HandleLogicStateChanged;
            }

            _idleState = new StateAnimLib.IdleAnimState(this);
            _runState = new StateAnimLib.RunAnimState(this);
            _dashState = new StateAnimLib.DashAnimState(this);

            ChangeState(_idleState);
        }

        private void OnDestroy()
        {
            if (_stateManager != null)
            {
                _stateManager.OnStateChanged -= HandleLogicStateChanged;
            }
        }

        private void HandleLogicStateChanged(IState logicState)
        {
            if (logicState is StateLibrary.IdleState) ChangeState(_idleState);
            else if (logicState is StateLibrary.RunState) ChangeState(_runState);
            else if (logicState is StateLibrary.DashState) ChangeState(_dashState);
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

