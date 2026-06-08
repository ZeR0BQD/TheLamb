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
                _stateAnimManager._animator.SetFloat("Speed", 0f);
            }
            public void Execute() { }
            public void Exit() { }
        }

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
                _stateAnimManager._animator.SetFloat("Speed", _stateAnimManager._inputReader.MoveInput.sqrMagnitude);
                if (_stateAnimManager._inputReader.MoveInput != Vector2.zero)
                {
                    _stateAnimManager._animator.SetFloat("DirecX", _stateAnimManager._inputReader.MoveInput.x);
                    _stateAnimManager._animator.SetFloat("DirecY", _stateAnimManager._inputReader.MoveInput.y);
                }
            }

            public void Exit() { }
        }

        public class DashAnimState : IAnimState
        {
            StateAnimManager _stateAnimManager;
            public DashAnimState(StateAnimManager stateAnimManager)
            {
                _stateAnimManager = stateAnimManager;
            }
            public void Enter()
            {
                _stateAnimManager._animator.SetBool("Roll", true);
            }
            public void Execute() { }
            public void Exit()
            {
                _stateAnimManager._animator.SetBool("Roll", false);
            }
        }
    }
}

