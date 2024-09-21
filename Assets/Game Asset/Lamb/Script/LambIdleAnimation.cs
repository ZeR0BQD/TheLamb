using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambIdleAnimation : StateMachineBehaviour
{
    PlayerAnim direcMove;
    SpriteRenderer spriteR;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerAnim direcMove = animator.GetComponent<PlayerAnim>();
        spriteR = animator.GetComponent<SpriteRenderer>();
        spriteR.flipX = direcMove.lastDirecMove == -1 ? true : false;
        Debug.Log(direcMove.lastDirecMove);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spriteR.flipX = false;
    }
}
