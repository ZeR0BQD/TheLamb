using UnityEngine;
using Behavior.Player;
namespace StatePattern.Player
{
    public class StateLibrary
    {
        public class MoveState : IState
        {
            private BehaviorManager _BehaviorManager;
            private readonly PlayerController _player;

            public MoveState(PlayerController player, BehaviorManager BehaviorManager)
            {
                _player = player;
                _BehaviorManager = BehaviorManager;
            }
            public void Enter()
            {

            }

            public void Execute()
            {
                _BehaviorManager.ExecuteMove(_player);
            }

            public void Exit()
            {
                _BehaviorManager.ExecuteMove(_player);
            }
        }
        //---------------------------------------
    }
}