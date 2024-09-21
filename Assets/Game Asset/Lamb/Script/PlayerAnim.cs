using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    [HideInInspector] public float lastPositionX, lastDirecMove;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        lastPositionX = transform.position.x;
    }
    void Update()
    {
        Flip();
        animator.SetFloat("Speed", playerMovement.move.magnitude);
        animator.SetFloat("DirecX", playerMovement.move.x);
        animator.SetFloat("DirecY", playerMovement.move.y);
    }

    void Flip()
    {
        if (lastPositionX > transform.position.x) lastDirecMove = -1;
        else if (lastPositionX < transform.position.x) lastDirecMove = 1;
        lastPositionX = transform.position.x;
    }
}
