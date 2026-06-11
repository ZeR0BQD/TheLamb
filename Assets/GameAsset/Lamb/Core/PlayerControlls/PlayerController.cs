using Data.Player;
using StatePattern.Player;
using StatePattern.Player.Anim;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(StateAnimManager))]
[RequireComponent(typeof(StateManager))]
public class PlayerController : MonoBehaviour, IPlayerPhysics
{
    [field: SerializeField] public PlayerDataSO playerData { get; private set; }
    public Rigidbody2D rig2D { get; private set; }
    [field: SerializeField] public LayerMask wallLayer { get; private set; }
    public Vector2 lastDirecMove { get; private set; }

    public Animator animator { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public StateManager stateManager { get; private set; }
    public StateAnimManager stateAnimManager { get; private set; }

    private IInputReader _inputReader;

    public void Initialize(IInputReader inputReader)
    {
        _inputReader = inputReader;

        stateManager.Initialize(_inputReader, (IPlayerPhysics)this);
        stateAnimManager.Initialize(_inputReader, stateManager);
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
        {

        }
    }

    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stateManager = GetComponent<StateManager>();
        stateAnimManager = GetComponent<StateAnimManager>();
    }

    private void Start()
    {
        lastDirecMove = Vector2.right;
    }

    private void Update()
    {
        if (_inputReader != null && _inputReader.MoveInput != Vector2.zero)
        {
            lastDirecMove = _inputReader.MoveInput.normalized;
        }
    }

}