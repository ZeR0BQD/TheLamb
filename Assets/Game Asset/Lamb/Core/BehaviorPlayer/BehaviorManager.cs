using UnityEngine;
namespace Behavior.Player
{
    public class BehaviorManager
    {
        private BehaviorLibrary _moveBehavior;

        public BehaviorManager()
        {
            _moveBehavior = new BehaviorLibrary();
        }

        public void execBehavior(PlayerController player, Vector2 moveInput)
        {
            _moveBehavior.Run(player, moveInput);
        }
    }
}