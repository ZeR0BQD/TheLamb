
namespace StatePattern.Player
{
    public interface IState
    {
        void Enter();
        void Execute();
        void FixedExecute();
        void Exit();
        void OnDashSignal();
    }
}