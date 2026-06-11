using UnityEngine;

namespace StatePattern.Player.Anim
{
    public class StateAnimLib
    {
        public class IdleAnimState : IAnimState
        {
            private readonly StateAnimManager _stateAnimManager;

            public IdleAnimState(StateAnimManager stateAnimManager)
            {
                _stateAnimManager = stateAnimManager;
            }

            public void Enter()
            {
                _stateAnimManager.Animator.SetFloat("Speed", 0f);
            }

            public void Execute() { }
            public void Exit() { }
        }

        public class RunAnimState : IAnimState
        {
            private readonly StateAnimManager _stateAnimManager;

            public RunAnimState(StateAnimManager stateAnimManager)
            {
                _stateAnimManager = stateAnimManager;
            }

            public void Enter() { }

            public void Execute()
            {
                Vector2 moveInput = _stateAnimManager.InputReader.MoveInput;
                _stateAnimManager.Animator.SetFloat("Speed", moveInput.sqrMagnitude);

                if (moveInput != Vector2.zero)
                {
                    _stateAnimManager.Animator.SetFloat("DirecX", moveInput.x);
                    _stateAnimManager.Animator.SetFloat("DirecY", moveInput.y);
                }
            }

            public void Exit() { }
        }

        public class DashAnimState : IAnimState
        {
            private readonly StateAnimManager _stateAnimManager;

            public DashAnimState(StateAnimManager stateAnimManager)
            {
                _stateAnimManager = stateAnimManager;
            }

            public void Enter()
            {
                _stateAnimManager.Animator.SetBool("Roll", true);
            }

            public void Execute() { }

            public void Exit()
            {
                _stateAnimManager.Animator.SetBool("Roll", false);
            }
        }
    }
}
