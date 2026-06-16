using Behavior.Player;

namespace StatePattern.Player
{
    public class PlayerStateContext
    {
        public StateManager StateManager { get; }
        public IInputReader InputReader { get; }
        public IRunnable RunAction { get; }
        public IDashable DashAction { get; }

        public PlayerStateContext(StateManager stateManager, IInputReader inputReader, IRunnable runAction, IDashable dashAction)
        {
            StateManager = stateManager;
            InputReader = inputReader;
            RunAction = runAction;
            DashAction = dashAction;
        }
    }
}
