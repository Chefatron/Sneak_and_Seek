using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAnimator : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent navMeshAgent;

    Vector3 pos;
    Vector3 nextPos;

    // Update is called once per frame
    void Update()
    {
        pos = GetComponentInParent<Transform>().position;
        nextPos = navMeshAgent.destination;

        //Debug.Log(Mathf.Abs(nextPos.x - pos.x));
        //Debug.Log(Mathf.Abs(nextPos.z - pos.z));

        if (Mathf.Abs(nextPos.x - pos.x) > Mathf.Abs(nextPos.z - pos.z))
        {
            if (nextPos.x < pos.x)
            {
                animator.SetInteger("Move_X", -1);
                animator.SetInteger("Move_Y", 0);
            }
            else if (nextPos.x > pos.x)
            {
                animator.SetInteger("Move_X", 1);
                animator.SetInteger("Move_Y", 0);
            }
            else
            {
                animator.SetInteger("Move_X", 0);
                animator.SetInteger("Move_Y", 0);
            }
        }
        else if (Mathf.Abs(nextPos.x - pos.x) < Mathf.Abs(nextPos.z - pos.z))
        {
            if (nextPos.z < pos.z)
            {
                animator.SetInteger("Move_X", 0);
                animator.SetInteger("Move_Y", -1);
            }
            else if (nextPos.z > pos.z)
            {
                animator.SetInteger("Move_X", 0);
                animator.SetInteger("Move_Y", 1);
            }
            else
            {
                animator.SetInteger("Move_X", 0);
                animator.SetInteger("Move_Y", 0);
            }
        }
    }
}
