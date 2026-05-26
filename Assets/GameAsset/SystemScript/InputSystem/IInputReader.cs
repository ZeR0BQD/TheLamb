using UnityEngine;
using System;

public interface IInputReader
{
    Vector2 MoveInput { get; }
    event Action<Vector2> OnMoveEvent;
    event Action OnDashEvent;
    event Action OnAttackEvent;
}
