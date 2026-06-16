namespace StatePattern.Player
{
    public abstract class PlayerBaseState : IState
    {
        protected readonly PlayerStateContext _ctx;

        protected StateManager _stateManager => _ctx.StateManager;
        protected IInputReader _inputReader => _ctx.InputReader;

        public abstract IDStatePlayer StateID { get; }

        public PlayerBaseState(PlayerStateContext ctx)
        {
            _ctx = ctx;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Execute() { }
        public virtual void FixedExecute() { }

        // Logic chuyển sang trạng thái Lướt
        public virtual void OnStateChangeRequest(IDStatePlayer id)
        {
            _stateManager.ChangeState(id);
        }
    }
}
