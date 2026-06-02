using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour, IInputReader
{
    public Vector2 MoveInput { get; private set; }
    public event Action<Vector2> OnMoveEvent;
    public event Action OnDashEvent;
    public event Action OnAttackEvent;

    private PlayerControlsInput _controls;

    private void Awake()
    {
        _controls = new PlayerControlsInput();


        //Đăng ký sự kiện di chuyển

        _controls.Player.Move.performed += ctx =>
                {
                    MoveInput = ctx.ReadValue<Vector2>();
                    OnMoveEvent?.Invoke(MoveInput);
                };


        // Hủy di chuyển

        _controls.Player.Move.canceled += ctx =>
        {
            MoveInput = Vector2.zero;
            OnMoveEvent?.Invoke(MoveInput);
        };

        // Đăng ký sự kiện Lướt (Dash)
        _controls.Player.Dash.performed += ctx =>
        {
            OnDashEvent?.Invoke();
        };

    }

    private void OnEnable()
    {
        _controls?.Enable();
    }

    private void OnDisable()
    {
        _controls?.Disable();
    }
}
