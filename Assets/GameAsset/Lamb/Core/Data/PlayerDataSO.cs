using UnityEngine;

namespace Data.Player
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Scriptable Objects/TheLamb/Data/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [Header("Movement")]
        public float moveSpeed = 5f;

        [Header("Dash")]
        public float dashDistance = 3f;
        public float dashDuration = 0.2f;

        private void Reset()
        {
            moveSpeed = 5f;
            dashDistance = 3f;
            dashDuration = 0.2f;
        }
    }
}
