using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_fall : StateMachineBehaviour
{
    Rigidbody2D rb;
    override public void OnStateEnter(Animator animatior, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animatior.GetComponent<Rigidbody2D>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rb.velocity.y <= 0.05)
        {
            animator.SetBool("Fall", false);
        }
    }
}
