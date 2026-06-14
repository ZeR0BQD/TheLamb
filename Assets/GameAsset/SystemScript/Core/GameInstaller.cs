using UnityEngine;

namespace Core.Installers
{
    public class GameInstaller : MonoBehaviour
    {

        private void Start()
        {
            bool allValid = true;

            PlayerInputReader activeInput = FindRequired<PlayerInputReader>(ref allValid);
            PlayerController activePlayer = FindRequired<PlayerController>(ref allValid);
            CameraFollow cameraFollow = FindRequired<CameraFollow>(ref allValid);

            if (allValid)
            {
                activePlayer.Initialize(activeInput);
                cameraFollow.Initialize(activePlayer.transform);
            }
            else
            {
                Debug.LogError("[GameInstaller] Khoi tao that bai");
            }
        }

        private T FindRequired<T>(ref bool allValid) where T : Object
        {
            var found = FindFirstObjectByType<T>();
            if (found == null)
            {
                Debug.LogError($"[GameInstaller] Khong tim thay {typeof(T).Name} trong scene");


                allValid = false;
            }
            return found;
        }
    }
}
