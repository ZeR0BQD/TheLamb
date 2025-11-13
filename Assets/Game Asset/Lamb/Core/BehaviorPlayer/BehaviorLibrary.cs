using UnityEngine;
using DG.Tweening;
namespace Behavior.Player
{
    public class BehaviorLibrary : IRunnable, IDashable
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

            RaycastHit2D hit = Physics2D.Raycast(_player.rig2D.position + dashDirection * 0.1f, dashDirection, distance, _player.wallLayer);

            if (hit.collider != null)
            {
                distance = hit.distance - 0.1f;
            }

            Vector2 dashTarget = _player.rig2D.position + dashDirection * distance;
            return _player.rig2D.DOMove(dashTarget, _player.dashDuration * (distance / _player.dashDistance)).SetEase(Ease.OutQuad);
        }
    }
}