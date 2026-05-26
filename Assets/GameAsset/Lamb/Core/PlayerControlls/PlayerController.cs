using StatePattern.Player;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(StateAnimManager))]
[RequireComponent(typeof(StateManager))]
public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float dashDistance { get; private set; }
    [field: SerializeField] public float dashDuration { get; private set; }
    public Rigidbody2D rig2D { get; private set; }
    [field: SerializeField] public LayerMask wallLayer { get; private set; }
    [field: SerializeField] public Vector2 moveInput { get; private set; }
    public Vector2 lastDirecMove { get; private set; }
    public Animator animator { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }

    private IInputReader _inputReader;

    public void Initialize(IInputReader inputReader)
    {
        _inputReader = inputReader;
        if (_inputReader != null)
        {
            _inputReader.OnMoveEvent += HandleMove;
        }
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
        {
            _inputReader.OnMoveEvent -= HandleMove;
        }
    }

    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();
        rig2D.interpolation = RigidbodyInterpolation2D.Interpolate;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        lastDirecMove = Vector2.right;
    }

    private void HandleMove(Vector2 input)
    {
        moveInput = input;
        if (moveInput.x != 0)
        {
            lastDirecMove = new Vector2(moveInput.x, 0).normalized;
        }
    }

    private void Reset()
    {
        moveSpeed = 5f;
        dashDistance = 5f;
        dashDuration = 0.35f;
    }
}