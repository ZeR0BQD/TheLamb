using System.Collections.Generic;
using Behavior.Player;
using UnityEngine;

namespace StatePattern.Player
{
    public partial class StateManager : MonoBehaviour
    {
        private IState _currentState;
        private readonly List<System.Action> _cleanups = new();

        public IPlayerPhysics _physics { get; private set; }

        private readonly Dictionary<IDStatePlayer, IState> _states = new Dictionary<IDStatePlayer, IState>();
        private IInputReader _inputReader;
        private BehaviorLibrary _playerActions;
        public IDashable DashAction => _playerActions;


        public void Initialize(IInputReader inputReader, IPlayerPhysics physics)
        {
            _physics = physics;
            _inputReader = inputReader;

            if (_inputReader != null)
            {
                BindEvent(() => RequestState(IDStatePlayer.Dash), h => _inputReader.OnDashEvent += h, h => _inputReader.OnDashEvent -= h);
            }

            _playerActions = new BehaviorLibrary(inputReader, _physics);
            var ctx = new PlayerStateContext(this, _inputReader, _playerActions, _playerActions);

            InitializeStates(ctx);

            ChangeState(IDStatePlayer.Idle);
        }



        private void RequestState(IDStatePlayer targetState)
        {
            _currentState?.OnStateChangeRequest(targetState);
        }
        private void BindEvent(System.Action handler, System.Action<System.Action> subscribe, System.Action<System.Action> unsubscribe)
        {
            subscribe(handler);
            _cleanups.Add(() => unsubscribe(handler));
        }


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
            _currentState?.Enter();
        }


        private void Update()
        {
            _currentState?.Execute();
        }

        private void FixedUpdate()
        {
            _currentState?.FixedExecute();
        }

        private void OnDestroy()
        {
            foreach (var cleanup in _cleanups)
                cleanup();

            _cleanups.Clear();
        }
    }
}