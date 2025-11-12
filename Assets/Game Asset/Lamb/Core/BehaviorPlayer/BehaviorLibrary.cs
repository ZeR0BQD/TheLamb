using UnityEngine;
using DG.Tweening;
namespace Behavior.Player
{
    public class BehaviorLibrary : IBehavior
    {
        public void Run(PlayerController _player)
        {
            if (_player == null) return;

            Vector2 moveDirection = _player.moveInput.normalized;

            _player.rig2D.MovePosition(_player.rig2D.position + moveDirection * _player.moveSpeed * Time.fixedDeltaTime);
        }
        public Tween Dash(PlayerController _player)
        {
            if (_player == null) return null;

            Vector2 dashDirection = _player.moveInput == Vector2.zero ? _player.lastDirecMove : _player.moveInput.normalized;

            float distance = _player.dashDistance;

            // Bắn một tia Raycast để kiểm tra va chạm với tường
            // Chúng ta thêm một khoảng nhỏ (0.1f) vào vị trí bắt đầu để tránh tia cast bị kẹt bên trong collider của chính player
            RaycastHit2D hit = Physics2D.Raycast(_player.rig2D.position + dashDirection * 0.1f, dashDirection, distance, _player.wallLayer);

            // Nếu tia cast chạm vào tường
            if (hit.collider != null)
            {
                // Tính toán lại khoảng cách dash để dừng ngay sát tường
                // Trừ đi một khoảng nhỏ (ví dụ: 0.1f) để nhân vật không bị "dính" vào tường
                distance = hit.distance - 0.1f;
            }

            Vector2 dashTarget = _player.rig2D.position + dashDirection * distance;

            // Sử dụng một phiên bản khác của DOMove để điều chỉnh thời gian dựa trên khoảng cách mới
            // (distance / _player.dashDistance) sẽ cho ra tỉ lệ. Ví dụ: nếu chỉ dash được nửa đường, thời gian cũng giảm một nửa.
            // Điều này giữ cho tốc độ dash luôn không đổi.
            return _player.rig2D.DOMove(dashTarget, _player.dashDuration * (distance / _player.dashDistance)).SetEase(Ease.OutQuad);
        }
    }
}