
using UnityEngine;

namespace Behavior.Player
{
    public class BehaviorManager
    {
        private BehaviorLibrary.Move _moveBehavior;

        // Constructor: Khởi tạo các behavior cần thiết
        public BehaviorManager()
        {
            _moveBehavior = new BehaviorLibrary.Move();
        }

        // Phương thức này sẽ được gọi từ State để thực thi logic di chuyển
        public void ExecuteMove(PlayerController player)
        {
            // Gọi đến phương thức Run() trong BehaviorLibrary.Move
            _moveBehavior.Run(player);
        }
    }
}