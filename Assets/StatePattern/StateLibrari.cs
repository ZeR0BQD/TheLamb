using UnityEngine;

namespace StatePattern.Player
{
    public class StateLibrari
    {
        public class IdleState : IState
        {
            private PlayerController _player;
            public IdleState(PlayerController player)
            {
                _player = player;
            }
            public void Enter()
            {
                Debug.Log("Entering Idle State");
            }

            public void Execute()
            {
                Debug.Log("Executing Idle State");
            }

            public void Exit()
            {
                Debug.Log("Exiting Idle State");
            }
        }
        //----------------------------------------
        public class MoveState : IState
        {
            private PlayerController _player;
            public MoveState(PlayerController player)
            {
                _player = player;
            }
            public void Enter()
            {
                Debug.Log("Entering Move State");
            }

            public void Execute()
            {
                Debug.Log("Executing Move State");
            }

            public void Exit()
            {
                Debug.Log("Exiting Move State");
            }
        }
    }
}