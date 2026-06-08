using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map
{
    // Tạo menu tiện lợi trong Unity
    [CreateAssetMenu(fileName = "NewCustomRuleTile", menuName = "Scriptable Objects/Map/Custom Rule Tile")]
    public class CustomRuleTile : RuleTile
    {
        [Header("Ground Logic Data")]
        [Tooltip("Kéo file dữ liệu đất (ví dụ: LavaData) vào đây")]
        public MakeTypeGround groundData;
    }
}
