namespace StatePattern.Player.Anim
{
    public interface IAnimState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}