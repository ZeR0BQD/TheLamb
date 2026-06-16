using UnityEngine;

namespace StatePattern.Player.Anim
{
    public class RunAnimState : PlayerBaseStateAnim
    {
        public override IDStatePlayer StateID => IDStatePlayer.Run;

        public RunAnimState(PlayerAnimStateContext ctx) : base(ctx)
        {
        }

        public override void Execute()
        {
            Vector2 moveInput = _inputReader.MoveInput;
            _stateManager.Animator.SetFloat("Speed", moveInput.sqrMagnitude);

            if (moveInput != Vector2.zero)
            {
                _stateManager.Animator.SetFloat("DirecX", moveInput.x);
                _stateManager.Animator.SetFloat("DirecY", moveInput.y);
            }
        }
    }
}
