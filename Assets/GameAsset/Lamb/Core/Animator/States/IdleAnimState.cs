using UnityEngine;

namespace StatePattern.Player.Anim
{
    public class IdleAnimState : PlayerBaseStateAnim
    {
        public override IDStatePlayer StateID => IDStatePlayer.Idle;

        public IdleAnimState(PlayerAnimStateContext ctx) : base(ctx)
        {

        }

        public override void Enter()
        {
            _stateManager.Animator.SetFloat("Speed", 0f);
        }

        public override void Execute()
        {
            if (_inputReader.MoveInput != Vector2.zero)
            {
                _stateManager.ChangeState(IDStatePlayer.Run);
            }
        }
    }
}
