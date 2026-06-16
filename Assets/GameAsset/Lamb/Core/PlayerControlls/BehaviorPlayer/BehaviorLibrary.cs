using DG.Tweening;
using UnityEngine;

namespace Behavior.Player
{
    public class BehaviorLibrary : IRunnable, IDashable
    {
        private readonly IInputReader _inputReader;
        private readonly IPlayerPhysics _physics;

        public BehaviorLibrary(IInputReader inputReader, IPlayerPhysics physics)
        {
            _inputReader = inputReader;
            _physics = physics;
        }

        public void Run()
        {
            if (_physics == null || _physics.playerData == null)
            {
                Debug.LogError("[BehaviorLibrary] IPlayerPhysics hoac PlayerData bi NULL!");
                return;
            }

            Vector2 moveDirection = _inputReader.MoveInput.normalized;
            _physics.rig2D.MovePosition(_physics.rig2D.position + moveDirection * _physics.playerData.moveSpeed * Time.fixedDeltaTime);
        }

        public event System.Action OnDashComplete;

        public Tween Dash()
        {
            if (_physics == null || _physics.playerData == null)
            {
                Debug.LogError("[BehaviorLibrary] IPlayerPhysics hoac PlayerData bi NULL! Khong the thuc hien Dash.");
                return null;
            }

            Vector2 dashDirection = _inputReader.MoveInput == Vector2.zero
                ? _physics.lastDirecMove
                : _inputReader.MoveInput.normalized;

            float distance = _physics.playerData.dashDistance;

            RaycastHit2D hit = Physics2D.Raycast(
                _physics.rig2D.position + dashDirection * 0.1f,
                dashDirection,
                distance,
                _physics.wallLayer
            );

            if (hit.collider != null)
            {
                distance = hit.distance - 0.1f;
                Debug.Log("Dash hit wall, new distance: " + distance);
            }

            Vector2 dashTarget = _physics.rig2D.position + dashDirection * distance;
            return _physics.rig2D
                .DOMove(dashTarget, _physics.playerData.dashDuration * (distance / _physics.playerData.dashDistance))
                .SetEase(Ease.OutQuad)
                .OnComplete(() => OnDashComplete?.Invoke());
        }
    }
}
