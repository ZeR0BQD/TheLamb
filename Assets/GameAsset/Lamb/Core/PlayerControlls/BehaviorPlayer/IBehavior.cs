using DG.Tweening;
namespace Behavior.Player
{
    public interface IRunnable
    {
        void Run();
    }

    public interface IDashable
    {
        Tween Dash();
    }
}