using UnityEngine;

namespace Behavior.Player
{
    public class BehaviorLibrary
    {
        public class Move : IState
        {
            public void Run(PlayerController player)
            {
                if (player == null || player.rig2D == null) return;

                // Lấy input và thực hiện di chuyển
                // Logic này giờ chỉ tồn tại ở một nơi duy nhất, rất dễ quản lý

                // Chỉ lấy input và lưu lại, không thực hiện di chuyển ở đây.
                // Việc di chuyển sẽ được xử lý trong FixedUpdate của PlayerController.
                float moveX = Input.GetAxisRaw("Horizontal");
                float moveY = Input.GetAxisRaw("Vertical");
                player.move = new Vector2(moveX, moveY).normalized;
                player.rig2D.MovePosition(player.rig2D.position + player.move * player.moveSpeed * Time.fixedDeltaTime);
            }
        }
    }
}