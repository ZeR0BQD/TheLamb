using UnityEngine;
using StatePattern.Player;
[RequireComponent(typeof(StateManager))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float powerDash { get; private set; }
    [field: SerializeField] public float timeDash { get; private set; }
    public Vector2 move;
    public Rigidbody2D rig2D { get; private set; }
    private StateManager _stateManager;

    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();
        _stateManager = GetComponent<StateManager>();
        rig2D.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _stateManager.ChangeState(_stateManager._moveState);
        }
        else
        {
            _stateManager.ChangeState(_stateManager._idleState);
        }
    }
}