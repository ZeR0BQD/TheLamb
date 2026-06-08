using UnityEngine;

namespace Map
{
    [CreateAssetMenu(fileName = "NewGroundData", menuName = "Scriptable Objects/Map/Ground Data")]
    public class MakeTypeGround : ScriptableObject
    {
        [Header("General Info")]
        [Tooltip("Tên loại đất để hiển thị hoặc log (VD: Dung Nham, Bùn Lầy)")]
        public string groundName = "Mặt đất thường";

        [Header("Movement Modifiers")]
        [Tooltip("Hệ số nhân tốc độ. 1 = Bình thường, 0.5 = Chậm đi một nửa, 2 = Nhanh gấp đôi.")]
        public float speedMultiplier = 1f;

        [Header("Damage Modifiers")]
        [Tooltip("Lượng máu bị trừ mỗi giây khi đứng trên nền đất này.")]
        public float damagePerSecond = 0f;

        [Header("Abilities")]
        [Tooltip("Có cho phép dùng kỹ năng lướt (Dash) trên nền đất này không?")]
        public bool canDash = true;
    }
}