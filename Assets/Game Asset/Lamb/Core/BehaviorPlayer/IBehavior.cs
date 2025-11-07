using UnityEngine;
namespace Behavior.Player
{
    public interface IBehavior
    {
        void Run(PlayerController player, Vector2 moveInput);
    }
}