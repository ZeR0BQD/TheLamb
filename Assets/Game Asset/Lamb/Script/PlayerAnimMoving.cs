using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimMoving : MonoBehaviour
{
    Animator animator;
    PlayerController _player;
    [HideInInspector] public float lastPositionX, lastDirecMove;

    // public PlayerAnimMoving(PlayerController player)
    // {
    //     _player = player;
    // }
    void Start()
    {
        _player = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        lastPositionX = transform.position.x;
    }
    void Update()
    {
        Debug.Log(_player.move);
        Flip();
        animator.SetFloat("Speed", _player.move.magnitude);
        animator.SetFloat("DirecX", _player.move.x);
        animator.SetFloat("DirecY", _player.move.y);
    }

    void Flip()
    {
        if (lastPositionX > transform.position.x) lastDirecMove = -1;
        else if (lastPositionX < transform.position.x) lastDirecMove = 1;
        lastPositionX = transform.position.x;
    }
}
