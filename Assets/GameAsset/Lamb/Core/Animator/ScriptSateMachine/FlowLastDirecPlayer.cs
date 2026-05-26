using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowLastDirecPlayer : StateMachineBehaviour
{
    PlayerController _player;
    SpriteRenderer spriteR;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = animator.GetComponent<PlayerController>();
        spriteR = _player.spriteRenderer;
        spriteR.flipX = _player.lastDirecMove.x < 0;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spriteR.flipX = false;
    }
}
