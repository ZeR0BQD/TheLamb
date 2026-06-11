using Behavior.Player;
using StatePattern.Player;
using UnityEngine;

namespace StatePattern.Player.States
{
    public class RunState : PlayerBaseState
    {
        public override IDStatePlayer StateID => IDStatePlayer.Run;

        private readonly IRunnable _runAction;

        public RunState(PlayerStateContext ctx) : base(ctx)
        {
            _runAction = ctx.RunAction;
        }

        public override void Execute()
        {
            if (_inputReader.MoveInput == Vector2.zero)
            {
                _stateManager.ChangeState(IDStatePlayer.Idle);
            }
        }

        public override void FixedExecute()
        {
            _runAction.Run();
        }
    }
}
