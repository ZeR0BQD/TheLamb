using UnityEngine;

namespace Behavior.Player
{
    public class BehaviorLibrary : IState
    {
        public void Run(PlayerController player)
        {
            if (player == null || player.rig2D == null) return;
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            player.move = new Vector2(moveX, moveY).normalized;
            player.rig2D.MovePosition(player.rig2D.position + player.move * player.moveSpeed * Time.fixedDeltaTime);
        }
    }
}