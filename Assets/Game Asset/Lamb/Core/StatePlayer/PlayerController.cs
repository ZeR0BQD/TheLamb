using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float powerDash { get; private set; }
    [field: SerializeField] public float timeDash { get; private set; }
    public Rigidbody2D rig2D { get; private set; }
    [field: SerializeField] public Vector2 moveInput { get; private set; }
    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}