using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambIdleAnimation : StateMachineBehaviour
{
    PlayerAnimMoving direcMove;
    SpriteRenderer spriteR;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerAnimMoving direcMove = animator.GetComponent<PlayerAnimMoving>();
        spriteR = animator.GetComponent<SpriteRenderer>();
        spriteR.flipX = direcMove.lastDirecMove == -1 ? true : false;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spriteR.flipX = false;
    }
}
