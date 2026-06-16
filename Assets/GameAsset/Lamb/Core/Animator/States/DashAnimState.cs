using Behavior.Player;

namespace StatePattern.Player.Anim
{
    public class DashAnimState : PlayerBaseStateAnim
    {
        public override IDStatePlayer StateID => IDStatePlayer.Dash;

        private readonly IDashable _dashAction;

        public DashAnimState(PlayerAnimStateContext ctx) : base(ctx)
        {
            _dashAction = ctx.DashAction;
        }

        public override void Enter()
        {
            _stateManager.Animator.SetBool("Roll", true);

            _dashAction.OnDashComplete += OnDashFinished;
        }

        public override void Exit()
        {
            _stateManager.Animator.SetBool("Roll", false);

            _dashAction.OnDashComplete -= OnDashFinished;
        }

        private void OnDashFinished()
        {
            _stateManager.ChangeState(IDStatePlayer.Idle);
        }

        public override void OnStateChangeRequest(IDStatePlayer id)
        {
            if (id == IDStatePlayer.Dash) return;

            base.OnStateChangeRequest(id);
        }
    }
}
