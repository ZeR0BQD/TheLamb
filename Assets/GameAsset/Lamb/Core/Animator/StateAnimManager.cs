using System.Collections.Generic;
using Behavior.Player;
using StatePattern.Player;
using UnityEngine;

namespace StatePattern.Player.Anim
{
    [RequireComponent(typeof(Animator))]
    public class StateAnimManager : MonoBehaviour
    {
        private readonly List<System.Action> _cleanups = new();
        private IAnimState _currentState;

        public Animator Animator { get; private set; }
        public IInputReader _inputReader { get; private set; }

        private Dictionary<IDStatePlayer, IAnimState> _states = new Dictionary<IDStatePlayer, IAnimState>();

        private void Awake()
        {
            Animator = GetComponent<Animator>();
        }

        public void Initialize(IInputReader inputReader, IDashable dashAction)
        {
            _inputReader = inputReader;


            if (_inputReader != null)
            {
                BindEvent(() => RequestState(IDStatePlayer.Dash), h => _inputReader.OnDashEvent += h, h => _inputReader.OnDashEvent -= h);
            }


            InitializeStates(_inputReader, dashAction);

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


        private void InitializeStates(IInputReader inputReader, IDashable dashAction)
        {
            var ctx = new PlayerAnimStateContext(this, inputReader, dashAction);
            RegisterState(new IdleAnimState(ctx));
            RegisterState(new RunAnimState(ctx));
            RegisterState(new DashAnimState(ctx));
        }
        private void RegisterState(IAnimState state)
        {
            _states[state.StateID] = state;
        }


        private void OnDestroy()
        {
            foreach (var cleanup in _cleanups)
                cleanup();

            _cleanups.Clear();
        }

        private void Update()
        {
            _currentState?.Execute();
        }
        public void ChangeState(IDStatePlayer id)
        {
            if (_states.TryGetValue(id, out IAnimState animState))
            {
                ChangeState(animState);
            }
            else
            {
                Debug.LogWarning($"[StateAnimManager] Khong tim thay state voi ID: {id}");
            }
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
