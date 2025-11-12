using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float dashDistance { get; private set; }
    [field: SerializeField] public float dashDuration { get; private set; }
    public Rigidbody2D rig2D { get; private set; }
    [field: SerializeField] public Vector2 moveInput { get; private set; }
    [field: SerializeField] public LayerMask wallLayer { get; private set; }
    public Vector2 lastDirecMove { get; private set; }
    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        lastDirecMove = Vector2.right;
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (moveInput.x != 0)
        {
            lastDirecMove = new Vector2(moveInput.x > 0 ? 1 : -1, 0);
        }
    }

    private void Reset()
    {
        moveSpeed = 5f;
        dashDistance = 5f;
        dashDuration = 0.35f;
    }
}