using Behavior.Player;
using DG.Tweening;
using StatePattern.Player;

namespace StatePattern.Player.States
{
    public class DashState : PlayerBaseState
    {
        public override IDStatePlayer StateID => IDStatePlayer.Dash;

        private Tween _dashTween;
        private readonly IDashable _dashAction;

        public DashState(PlayerStateContext ctx) : base(ctx)
        {
            _dashAction = ctx.DashAction;
        }

        public override void Enter()
        {
            _stateManager._physics.rig2D.DOKill();
            
            _dashAction.OnDashComplete += OnDashFinished;
            _dashTween = _dashAction.Dash();
        }

        private void OnDashFinished()
        {
            _stateManager.ChangeState(IDStatePlayer.Idle);
        }

        public override void Exit()
        {
            _dashAction.OnDashComplete -= OnDashFinished;
            _dashTween?.Kill();
        }

        public override void OnStateChangeRequest(IDStatePlayer id)
        {
            // Đang lướt thì không cho lướt tiếp


            if (id == IDStatePlayer.Dash) return;

            base.OnStateChangeRequest(id);
        }
    }
}
