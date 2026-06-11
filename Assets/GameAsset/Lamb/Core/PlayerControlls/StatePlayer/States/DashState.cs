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
            _dashTween = _dashAction.Dash().OnComplete(() =>
            {
                _stateManager.ChangeState(IDStatePlayer.Idle);
            });
        }

        public override void Exit()
        {
            _dashTween?.Kill();
        }

        public override void OnDashSignal()
        {
            // Đang lướt thì không cho lướt tiếp
        }
    }
}
