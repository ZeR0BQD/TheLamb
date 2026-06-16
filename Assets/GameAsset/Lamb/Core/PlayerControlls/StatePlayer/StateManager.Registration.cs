using Behavior.Player;
using StatePattern.Player.States;

namespace StatePattern.Player
{
    // Muon them State moi chi can them 1 dong RegisterState() trong ham InitializeStates()
    public partial class StateManager
    {


        private void RegisterState(IState state)
        {
            _states[state.StateID] = state;
        }


        // Them State moi chi can them 1 dong RegisterState() o day
        private void InitializeStates(PlayerStateContext ctx)
        {
            RegisterState(new IdleState(ctx));
            RegisterState(new RunState(ctx));
            RegisterState(new DashState(ctx));
        }




    }
}
