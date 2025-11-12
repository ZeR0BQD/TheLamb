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
            public void FixedExecute() { }
        }
        //---------------------------------------
        public class MoveState : IState
        {
            private BehaviorManager _BehaviorManager;
            private StateManager _stateManager;
            public MoveState(BehaviorManager BehaviorManager, StateManager stateManager)
            {
                _BehaviorManager = BehaviorManager;
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
                _BehaviorManager.Get<BehaviorLibrary>().Run(_stateManager._player);
            }

            public void Exit()
            {
                // _BehaviorManager.Get<BehaviorLibrary>().Run(_stateManager._player);
            }
        }
        //---------------------------------------
        public class DashState : IState
        {
            private Tween _dashTween;
            private StateManager _stateManager;
            private BehaviorManager _BehaviorManager;

            public DashState(BehaviorManager behaviorManager, StateManager stateManager)
            {
                _stateManager = stateManager;
                _BehaviorManager = behaviorManager;
            }
            public void Enter()
            {
                _stateManager._player.rig2D.DOKill();
                _dashTween = _BehaviorManager.Get<BehaviorLibrary>().Dash(_stateManager._player).OnComplete(() =>
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