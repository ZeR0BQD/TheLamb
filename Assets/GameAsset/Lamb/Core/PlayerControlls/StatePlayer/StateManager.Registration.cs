using Behavior.Player;
using StatePattern.Player.States;

namespace StatePattern.Player
{
    // Muon them State moi: chi can them 1 dong RegisterState() trong ham InitializeStates()
    public partial class StateManager
    {
        private BehaviorLibrary _playerActions;

        public void Initialize(IInputReader inputReader, IPlayerPhysics physics)
        {
            _physics = physics;
            _inputReader = inputReader;

            if (_inputReader != null)
            {
                _inputReader.OnDashEvent += HandleDashEvent;
            }

            _playerActions = new BehaviorLibrary(inputReader, _physics);
            var ctx = new PlayerStateContext(this, _inputReader, _playerActions, _playerActions);

            InitializeStates(ctx);

            ChangeState(IDStatePlayer.Idle);
        }



        private void RegisterState(IState state)
        {
            _states[state.StateID] = state;
        }


        // Them State moi: chi can them 1 dong RegisterState() o day
        private void InitializeStates(PlayerStateContext ctx)
        {
            RegisterState(new IdleState(ctx));
            RegisterState(new RunState(ctx));
            RegisterState(new DashState(ctx));
        }


        private void OnDestroy()
        {
            if (_inputReader != null)
            {
                _inputReader.OnDashEvent -= HandleDashEvent;
            }
        }
    }
}
