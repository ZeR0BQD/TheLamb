using UnityEngine;
using Behavior.Player;
using DG.Tweening;

namespace StatePattern.Player
{
    public class StateLibrary
    {
        public class IdleState : IState
        {
            private StateManager _stateManager;

            public IdleState(StateManager stateManager)
            {
                _stateManager = stateManager;
            }

            public void Enter() { }
            public void Exit() { }

            public void Execute()
            {
                if (_stateManager._player.moveInput != Vector2.zero)
                {
                    _stateManager.ChangeState(_stateManager._moveState);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _stateManager.ChangeState(_stateManager._dashState);
                }
            }
            public void FixedExecute()
            {

            }
        }
        //---------------------------------------
        public class RunState : IState
        {
            private readonly IRunnable _runAction;
            private StateManager _stateManager;
            public RunState(IRunnable runAction, StateManager stateManager)
            {
                _runAction = runAction;
                _stateManager = stateManager;
            }

            public void Enter() { }

            public void Execute()
            {
                if (_stateManager._player.moveInput == Vector2.zero)
                {
                    _stateManager.ChangeState(_stateManager._idleState);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _stateManager.ChangeState(_stateManager._dashState);
                }
            }

            public void FixedExecute()
            {
                _runAction.Run(_stateManager._player);
            }

            public void Exit()
            {

            }
        }
        //---------------------------------------
        public class DashState : IState
        {
            private Tween _dashTween;
            private StateManager _stateManager;
            private readonly IDashable _dashAction;

            public DashState(IDashable dashAction, StateManager stateManager)
            {
                _stateManager = stateManager;
                _dashAction = dashAction;
            }
            public void Enter()
            {
                _stateManager._player.rig2D.DOKill();
                _dashTween = _dashAction.Dash(_stateManager._player).OnComplete(() =>
                {
                    _stateManager.ChangeState(_stateManager._idleState);
                });
            }
            public void Execute()
            {

            }
            public void FixedExecute()
            {

            }
            public void Exit()
            {
                _dashTween?.Kill();
            }
        }
        //---------------------------------------
    }
}