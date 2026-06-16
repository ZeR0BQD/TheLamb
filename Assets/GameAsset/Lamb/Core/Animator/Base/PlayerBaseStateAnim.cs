namespace StatePattern.Player.Anim
{
    public abstract class PlayerBaseStateAnim : IAnimState
    {
        protected readonly StateAnimManager _stateManager;
        protected readonly IInputReader _inputReader;

        public abstract IDStatePlayer StateID { get; }

        public PlayerBaseStateAnim(PlayerAnimStateContext ctx)
        {
            _stateManager = ctx.StateManager;
            _inputReader = ctx.InputReader;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Execute() { }
        public virtual void OnStateChangeRequest(IDStatePlayer id)
        {
            _stateManager.ChangeState(id);
        }
    }
}