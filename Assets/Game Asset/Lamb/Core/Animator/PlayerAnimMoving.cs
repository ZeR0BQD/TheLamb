using System.Collections;
using System.Collections.Generic;
using StatePattern.Player;
using UnityEngine;

public class PlayerAnimMoving : MonoBehaviour
{
    Animator animator => GetComponent<Animator>();
    StateManager _stateManager => GetComponent<StateManager>();
    void Update()
    {
        animator.SetFloat("Speed", _stateManager._player.moveInput.sqrMagnitude);
        animator.SetFloat("DirecX", _stateManager._player.moveInput.x);
        animator.SetFloat("DirecY", _stateManager._player.moveInput.y);
    }
}
