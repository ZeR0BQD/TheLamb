using System.Collections;
using System.Collections.Generic;
using StatePattern.Player;
using UnityEngine;

public class PlayerAnimMoving : MonoBehaviour
{
    Animator animator;
    StateManager _StateManager;
    [HideInInspector] public float lastPositionX, lastDirecMove;
    void Start()
    {
        _StateManager = GetComponent<StateManager>();
        animator = GetComponent<Animator>();
        lastPositionX = transform.position.x;
    }
    void Update()
    {
        Flip();
        animator.SetFloat("Speed", _StateManager.MoveInput.sqrMagnitude);
        animator.SetFloat("DirecX", _StateManager.MoveInput.x);
        animator.SetFloat("DirecY", _StateManager.MoveInput.y);
    }

    void Flip()
    {
        if (lastPositionX > transform.position.x) lastDirecMove = -1;
        else if (lastPositionX < transform.position.x) lastDirecMove = 1;
        lastPositionX = transform.position.x;
    }
}
