using DG.Tweening;
namespace Behavior.Player
{
    public interface IRunnable
    {
        void Run(PlayerController player);
    }

    public interface IDashable
    {
        Tween Dash(PlayerController player);
    }
}