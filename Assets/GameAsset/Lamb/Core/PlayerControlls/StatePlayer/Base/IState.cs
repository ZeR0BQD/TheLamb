
namespace StatePattern.Player
{
    public interface IState
    {
        IDStatePlayer StateID { get; }
        void Enter();
        void Execute();
        void FixedExecute();
        void Exit();
        void OnDashSignal();
    }
}