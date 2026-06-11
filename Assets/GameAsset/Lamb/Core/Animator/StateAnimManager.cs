using System.Collections.Generic;
using StatePattern.Player;
using UnityEngine;

namespace StatePattern.Player.Anim
{
    [RequireComponent(typeof(Animator))]
    public class StateAnimManager : MonoBehaviour
    {
        private IAnimState _currentState;

        public Animator Animator { get; private set; }
        public IInputReader InputReader { get; private set; }

        private IAnimState _idleState;
        private IAnimState _runState;
        private IAnimState _dashState;

        private StateManager _stateManager;
        private Dictionary<IDStatePlayer, IAnimState> _stateMapping;

        private void Awake()
        {
            Animator = GetComponent<Animator>();
        }

        public void Initialize(IInputReader inputReader, StateManager stateManager)
        {
            InputReader = inputReader;
            _stateManager = stateManager;

            if (_stateManager != null)
            {
                _stateManager.OnStateChanged += HandleLogicStateChanged;
            }

            _idleState = new StateAnimLib.IdleAnimState(this);
            _runState = new StateAnimLib.RunAnimState(this);
            _dashState = new StateAnimLib.DashAnimState(this);

            _stateMapping = new Dictionary<IDStatePlayer, IAnimState>
            {
                { IDStatePlayer.Idle, _idleState },
                { IDStatePlayer.Run,  _runState  },
                { IDStatePlayer.Dash, _dashState }
            };

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
            if (_stateMapping.TryGetValue(logicState.StateID, out IAnimState animState))
            {
                ChangeState(animState);
            }
            else
            {
                Debug.LogWarning($"[StateAnimManager] Chua co Anim State tuong ung cho logic state: {logicState.StateID}");
            }
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
