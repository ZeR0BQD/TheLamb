using UnityEngine;
using Behavior.Player;

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
                if (_stateManager.MoveInput != Vector2.zero)
                {
                    _stateManager.ChangeState(_stateManager._moveState);
                }
            }
            public void FixedExecute() { }
        }

        //---------------------------------------
        public class MoveState : IState
        {
            private BehaviorManager _BehaviorManager;
            private PlayerController _player;
            private StateManager _stateManager;
            public MoveState(PlayerController player, BehaviorManager BehaviorManager, StateManager stateManager)
            {
                _player = player;
                _BehaviorManager = BehaviorManager;
                _stateManager = stateManager;
            }

            public void Enter() { }

            public void Execute()
            {
                if (_stateManager.MoveInput == Vector2.zero)
                {
                    _stateManager.ChangeState(_stateManager._idleState);
                }
            }

            public void FixedExecute()
            {
                Vector2 currentInput = _stateManager.MoveInput;
                _BehaviorManager.Get<BehaviorLibrary>().Run(_player, currentInput);
            }

            public void Exit()
            {
                _BehaviorManager.Get<BehaviorLibrary>().Run(_player, Vector2.zero);
            }
        }
        //---------------------------------------
    }
}