using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSquidAnim : StateMachineBehaviour
{
    Squid squid;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        squid = animator.GetComponent<Squid>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Move
        if (Vector3.Distance(animator.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > squid.distanceAttackTarget && squid.attackState == false)
            if (Vector3.Distance(animator.transform.position, squid.playerTransform.position) > squid.distanceAttackTarget && squid.attackState == false)
            {
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, MoveToPoint(GameObject.FindGameObjectWithTag("Player").transform.position, animator.transform.position, 0.1f), squid.speed * Time.deltaTime);
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, MoveToPoint(squid.playerTransform.position, animator.transform.position, 0.1f), squid.speed * Time.deltaTime);
            }
            else
            {
                squid.attackState = true;
            }
    }

    Vector2 MoveToPoint(Vector2 A, Vector2 B, float H)
    {
        Vector2 BA = A - B;
        Vector2 BC = BA.normalized * H;
        Vector2 C = B + BC;
        return C;
    }
}
