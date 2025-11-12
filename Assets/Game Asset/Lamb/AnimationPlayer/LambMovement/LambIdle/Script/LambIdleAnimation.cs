using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambIdleAnimation : StateMachineBehaviour
{
    PlayerController _player;
    SpriteRenderer spriteR;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = animator.GetComponent<PlayerController>();
        spriteR = animator.GetComponent<SpriteRenderer>();
        spriteR.flipX = _player.lastDirecMove == Vector2.left ? true : false;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spriteR.flipX = false;
    }
}
