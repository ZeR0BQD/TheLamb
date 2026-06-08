using StatePattern;
using UnityEngine;

namespace StatePattern.Player
{
    public abstract class PlayerBaseState : IState
    {
        protected StateManager _stateManager;
        protected IInputReader _inputReader;

        public PlayerBaseState(StateManager stateManager, IInputReader inputReader)
        {
            _stateManager = stateManager;
            _inputReader = inputReader;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Execute() { }
        public virtual void FixedExecute() { }

        // Logic chuyển sang trạng thái Lướt
        public virtual void OnDashSignal()
        {
            _stateManager.ChangeState(_stateManager._dashState);
        }
    }


}

