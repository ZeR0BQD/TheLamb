using UnityEngine;
using UnityEngine.Tilemaps;
using Map;

public class GroundDetectorTest : MonoBehaviour
{
    [Header("Setup")]
    [Tooltip("Kéo Tilemap mặt đất từ cửa sổ Hierarchy thả vào đây")]
    public Tilemap groundTilemap;

    private Vector3Int lastCellPosition;
    // Thêm biến này để nhớ xem loại đất trước đó dẫm lên là gì
    private MakeTypeGround lastGroundData; 

    void Update()
    {
        if (groundTilemap == null) return;

        Vector3Int currentCellPosition = groundTilemap.WorldToCell(transform.position);

        // Vẫn kiểm tra ô mới để tối ưu hiệu năng
        if (currentCellPosition != lastCellPosition)
        {
            lastCellPosition = currentCellPosition;
            CheckGroundLogic(currentCellPosition);
        }
    }

    private void CheckGroundLogic(Vector3Int cellPosition)
    {
        TileBase currentTile = groundTilemap.GetTile(cellPosition);
        MakeTypeGround currentData = null; // Tạo một biến tạm để giữ dữ liệu của ô hiện tại

        if (currentTile is CustomRuleTile ruleTile)
        {
            currentData = ruleTile.groundData;
        }

        // ĐÂY LÀ CHÌA KHÓA CHỐNG SPAM: Chỉ Log ra khi DỮ LIỆU ĐẤT thay đổi
        // Ví dụ: Bước từ ô Dung Nham 1 sang ô Dung Nham 2 -> Không Log
        // Bước từ ô Dung Nham sang ô Bùn Lầy -> Log
        if (currentData != lastGroundData)
        {
            if (currentData != null)
            {
                Debug.Log($"<color=cyan>Đang đứng trên:</color> {currentData.groundName}");
            }
            else
            {
                Debug.Log("Đang đứng trên: Đất thường (Trống)");
            }

            // Lưu lại loại đất hiện tại để lần sau so sánh
            lastGroundData = currentData;
        }
    }
}
