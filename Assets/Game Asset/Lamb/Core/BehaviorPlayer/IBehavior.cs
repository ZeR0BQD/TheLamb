using DG.Tweening;
namespace Behavior.Player
{
    public interface IBehavior
    {
        void Run(PlayerController _player);
        Tween Dash(PlayerController _player);
    }
}