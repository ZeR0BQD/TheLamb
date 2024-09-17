using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed, powerDash, timeDash;
    public GameObject ghost;
    bool isDash = false, canDash = true, direc = false;
    Rigidbody2D rig2D;
    Animator animator;
    SpriteRenderer sprite;
    [SerializeField] protected Joystick fixedJoystick;
    [HideInInspector] public Vector2 move;
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rig2D.interpolation = RigidbodyInterpolation2D.Interpolate;
    }
    void FixedUpdate()
    {
        Move();
        MoveAnim();
        Flip();
        if (Input.GetKeyDown(KeyCode.Space)) StartDash();
    }

    private void Reset()
    {
        this.LoadComponents();
        this.SetVariable();
    }

    protected void LoadComponents()
    {
        this.fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    protected void SetVariable()
    {
        this.moveSpeed = 5f;
        this.powerDash = 24f;
        this.timeDash = 0.2f;
    }

    public void StartDash()
    {
        if (canDash == true && move.magnitude != 0) StartCoroutine(Dash());
    }

    void Move()
    {
        // //Move with keyboard
        // float moveX = Input.GetAxisRaw("Horizontal");
        // float moveY = Input.GetAxisRaw("Vertical");

        //Move with joystick
        float moveX = fixedJoystick.Horizontal;
        float moveY = fixedJoystick.Vertical;

        move = new Vector2(moveX, moveY).normalized;
        rig2D.MovePosition(rig2D.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (move.x < 0) direc = true;
        else if (move.x > 0) direc = false;
        sprite.flipX = direc;
    }

    void MoveAnim()
    {
        animator.SetFloat("Speed", move.sqrMagnitude);
    }

    IEnumerator GhostEffect()
    {
        while (isDash)
        {
            Instantiate(ghost, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDash = true;
        moveSpeed += powerDash;
        StartCoroutine(GhostEffect());
        yield return new WaitForSeconds(timeDash);
        moveSpeed -= powerDash;
        StopCoroutine(GhostEffect());
        isDash = false;
        yield return new WaitForSeconds(0.4f);
        canDash = true;
    }
}
