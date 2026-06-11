using StatePattern.Player;
using UnityEngine;

namespace StatePattern.Player.States
{
    public class IdleState : PlayerBaseState
    {
        public override IDStatePlayer StateID => IDStatePlayer.Idle;

        public IdleState(PlayerStateContext ctx) : base(ctx) { }

        public override void Execute()
        {
            if (_inputReader.MoveInput != Vector2.zero)
            {
                _stateManager.ChangeState(IDStatePlayer.Run);
            }
        }
    }
}
