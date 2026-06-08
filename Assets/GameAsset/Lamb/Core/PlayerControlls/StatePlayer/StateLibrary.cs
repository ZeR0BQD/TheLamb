using Behavior.Player;
using DG.Tweening;
using UnityEngine;

namespace StatePattern.Player
{
    public class StateLibrary
    {
        public class IdleState : PlayerBaseState
        {
            public IdleState(StateManager stateManager, IInputReader inputReader) : base(stateManager, inputReader) { }

            public override void Execute()
            {
                if (_inputReader.MoveInput != Vector2.zero)
                {
                    _stateManager.ChangeState(_stateManager._moveState);
                }
            }
        }

        public class RunState : PlayerBaseState
        {
            private readonly IRunnable _runAction;

            public RunState(IRunnable runAction, StateManager stateManager, IInputReader inputReader) : base(stateManager, inputReader)
            {
                _runAction = runAction;
            }

            public override void Execute()
            {
                if (_inputReader.MoveInput == Vector2.zero)
                {
                    _stateManager.ChangeState(_stateManager._idleState);
                }
            }

            public override void FixedExecute()
            {
                _runAction.Run();
            }
        }

        public class DashState : PlayerBaseState
        {
            private Tween _dashTween;
            private readonly IDashable _dashAction;

            public DashState(IDashable dashAction, StateManager stateManager, IInputReader inputReader) : base(stateManager, inputReader)
            {
                _dashAction = dashAction;
            }

            public override void Enter()
            {
                _stateManager._physics.rig2D.DOKill();
                _dashTween = _dashAction.Dash().OnComplete(() =>
                {
                    _stateManager.ChangeState(_stateManager._idleState);
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
}