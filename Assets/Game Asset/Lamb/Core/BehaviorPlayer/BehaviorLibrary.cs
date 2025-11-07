using UnityEngine;

namespace Behavior.Player
{
    public class BehaviorLibrary : IBehavior
    {
        public void Run(PlayerController player, Vector2 moveInput)
        {
            if (player == null) return;

            Vector2 moveDirection = moveInput.normalized;

            player.rig2D.MovePosition(player.rig2D.position + moveDirection * player.moveSpeed * Time.fixedDeltaTime);
        }
    }
}