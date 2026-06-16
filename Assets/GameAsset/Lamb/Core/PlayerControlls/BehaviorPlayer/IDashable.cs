using DG.Tweening;

namespace Behavior.Player
{
    public interface IDashable
    {
        Tween Dash();
        event System.Action OnDashComplete;
    }
}
