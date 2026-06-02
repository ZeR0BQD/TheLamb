using UnityEngine;

namespace Core.Installers
{
    public class GameInstaller : MonoBehaviour
    {

        private void Start()
        {
            // Tự động tìm con Player và Input đang sống trên màn hình (Bỏ qua Prefab)
            PlayerInputReader activeInput = Object.FindFirstObjectByType<PlayerInputReader>();
            PlayerController activePlayer = Object.FindFirstObjectByType<PlayerController>();

            if (activePlayer != null && activeInput != null)
            {
                activePlayer.Initialize(activeInput);
                Debug.Log("GameInstaller: Tự động tìm thấy Player và tiêm Input thành công!");
            }
            else
            {
                Debug.LogError("GameInstaller: Không tìm thấy Player trên bản đồ hoặc thiếu InputReader!");
            }
        }
    }
}
