using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackSquidAnim : StateMachineBehaviour
{
    Squid squid;
    private Vector3 posTarget;
    float distanceBackTarget = 3f; //distanceBackTarget khoảng cách di chuyển ra sau target
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        squid = animator.GetComponent<Squid>();
        posTarget = FindPoint(GameObject.FindGameObjectWithTag("Player").transform.position, animator.transform.position, distanceBackTarget);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (squid.isAttack == true)
        {
            animator.speed = 0f;
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, posTarget, squid.speed * 7f * Time.deltaTime);
        }
        if (animator.transform.position == posTarget)
        {
            animator.speed = 1f;
            squid.attackState = false;
        }
    }
    Vector3 FindPoint(Vector2 A, Vector2 B, float H)
    {
        // A là vị trí của player, B là vị trí hiện tại của object, H là khoảng cách xuyên qua vị trí player
        // Tính vector từ A đến B
        Vector2 AB = B - A;

        // Tạo vector từ A đến C có độ dài H
        Vector2 AC = AB.normalized * (-H);

        // Tính tọa độ điểm C
        Vector2 C = A + AC;

        return C;
    }
}
