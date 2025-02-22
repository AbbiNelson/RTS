using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitFollowState : StateMachineBehaviour
{
    AttackController attackController;

    NavMeshAgent agent;

    public float attackingDistance = 1f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        attackController = animator.transform.GetComponent<AttackController>();
        agent = animator.transform.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        if (attackController.targetToAttack == null)
        {
            animator.SetBool("isFollow", false);
        }

        agent.SetDestination(attackController.targetToAttack.position);
        animator.transform.LookAt(attackController.targetToAttack);

        float distanceFromTarget = Vector3.Distance(attackController.targetToAttack.position, animator.transform.position);
        if (distanceFromTarget < attackingDistance)
        {
            animator.SetBool("isAttack", true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
    }
}
