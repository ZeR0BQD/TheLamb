namespace StatePattern.Player.Anim
{
    public interface IAnimState
    {
        IDStatePlayer StateID { get; }
        void Enter();
        void Execute();
        void Exit();
        void OnStateChangeRequest(IDStatePlayer id);
    }
}
