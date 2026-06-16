using Behavior.Player;

namespace StatePattern.Player.Anim
{
    public class PlayerAnimStateContext
    {
        public StateAnimManager StateManager { get; }
        public IInputReader InputReader { get; }
        public IDashable DashAction { get; }

        public PlayerAnimStateContext(StateAnimManager stateManager, IInputReader inputReader, IDashable dashAction)
        {
            StateManager = stateManager;
            InputReader = inputReader;
            DashAction = dashAction;
        }
    }
}
