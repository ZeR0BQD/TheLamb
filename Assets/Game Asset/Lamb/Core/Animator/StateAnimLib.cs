using UnityEngine;
namespace StatePattern.Player
{
    public class StateAnimLib
    {
        public class IdleAnimState : IAnimState
        {
            StateAnimManager _stateAnimManager;
            public IdleAnimState(StateAnimManager stateAnimManager)
            {
                _stateAnimManager = stateAnimManager;
            }
            public void Enter()
            {
                _stateAnimManager._player.animator.SetFloat("Speed", _stateAnimManager._player.moveInput.sqrMagnitude);
            }
            public void Execute()
            {
                if (_stateAnimManager._player.moveInput != Vector2.zero)
                {
                    _stateAnimManager.ChangeState(_stateAnimManager._runState);
                }
            }
            public void Exit() { }
        }
        //---------------------------------------
        public class RunAnimState : IAnimState
        {
            StateAnimManager _stateAnimManager;
            public RunAnimState(StateAnimManager stateAnimManager)
            {
                _stateAnimManager = stateAnimManager;
            }
            public void Enter() { }
            public void Execute()
            {
                if (_stateAnimManager._player.moveInput == Vector2.zero)
                {
                    _stateAnimManager.ChangeState(_stateAnimManager._idleState);
                }
                else
                {
                    _stateAnimManager._player.animator.SetFloat("Speed", _stateAnimManager._player.moveInput.sqrMagnitude);
                    _stateAnimManager._player.animator.SetFloat("DirecX", _stateAnimManager._player.moveInput.x);
                    _stateAnimManager._player.animator.SetFloat("DirecY", _stateAnimManager._player.moveInput.y);
                }
            }
            public void Exit() { }
        }

        public class DashAnimState : IAnimState
        {
            public void Enter() { }
            public void Execute() { }
            public void Exit() { }
        }
    }
}