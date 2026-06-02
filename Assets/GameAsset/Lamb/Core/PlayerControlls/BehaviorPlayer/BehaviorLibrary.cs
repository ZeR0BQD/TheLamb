using DG.Tweening;
using UnityEngine;
namespace Behavior.Player
{
    public class BehaviorLibrary : IRunnable, IDashable
    {
        public void Run(PlayerController _player)
        {
            if (_player == null || _player.playerData == null)
            {
                Debug.LogError("[BehaviorLibrary] PlayerController hoặc trường Player Data trong PlayerController bị NULL! Hãy kiểm tra lại Inspector");
                return;
            }

            Vector2 moveDirection = _player.moveInput.normalized;

            _player.rig2D.MovePosition(_player.rig2D.position + moveDirection * _player.playerData.moveSpeed * Time.fixedDeltaTime);
        }

        public Tween Dash(PlayerController _player)
        {
            if (_player == null || _player.playerData == null)
            {
                Debug.LogError("[BehaviorLibrary] Lỗi chí mạng: PlayerController hoặc trường Player Data trong PlayerController bị NULL! Không thể thực hiện Dash.");
                return null;
            }

            Vector2 dashDirection = _player.moveInput == Vector2.zero ? _player.lastDirecMove : _player.moveInput.normalized;

            float distance = _player.playerData.dashDistance;

            RaycastHit2D hit = Physics2D.Raycast(_player.rig2D.position + dashDirection * 0.1f, dashDirection, distance, _player.wallLayer);

            if (hit.collider != null)
            {
                distance = hit.distance - 0.1f;
                Debug.Log("Dash hit wall, new distance: " + distance);
            }

            Vector2 dashTarget = _player.rig2D.position + dashDirection * distance;
            return _player.rig2D.DOMove(dashTarget, _player.playerData.dashDuration * (distance / _player.playerData.dashDistance)).SetEase(Ease.OutQuad);
        }
    }
}