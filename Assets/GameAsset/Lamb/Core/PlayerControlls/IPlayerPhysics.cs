using Data.Player;
using UnityEngine;

public interface IPlayerPhysics
{
    Rigidbody2D rig2D { get; }
    PlayerDataSO playerData { get; }
    Vector2 lastDirecMove { get; }
    LayerMask wallLayer { get; }
}
