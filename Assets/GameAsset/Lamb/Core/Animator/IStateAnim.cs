namespace StatePattern.Player
{
    public interface IAnimState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}