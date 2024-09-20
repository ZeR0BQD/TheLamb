using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed, powerDash, timeDash;
    public GameObject ghost;
    protected bool isDash = false, canDash = true, direc = false;
    public Vector2 move;
    protected Vector2 direcDash = Vector2.down;
    Rigidbody2D rig2D;
    SpriteRenderer sprite;

    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        rig2D.interpolation = RigidbodyInterpolation2D.Interpolate;
    }
    void FixedUpdate()
    {
        //Move with keyboard
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        move = new Vector2(moveX, moveY).normalized;
        rig2D.MovePosition(rig2D.position + move * moveSpeed * Time.fixedDeltaTime);
        Flip();
    }
    private void Reset()
    {
        this.SetVariable();
    }

    protected void SetVariable()
    {
        this.moveSpeed = 5f;
        this.powerDash = 24f;
        this.timeDash = 0.2f;
    }

    void Flip()
    {
        if (move.x < 0) direc = true;
        else if (move.x > 0) direc = false;
        sprite.flipX = direc;
    }
}