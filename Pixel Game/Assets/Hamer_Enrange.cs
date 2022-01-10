using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hamer_Enrange : StateMachineBehaviour
{
    public float speed,walktime;
    Boss_Hamer boss;
    Transform Player;
    Rigidbody2D rb;

    override public void OnStateEnter(Animator animatior, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animatior.GetComponent<Rigidbody2D>();
        boss = animatior.GetComponent<Boss_Hamer>();
        walktime = 0;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        walktime += Time.deltaTime;
        Vector2 target = new Vector2(Player.position.x, Player.position.y);
        Vector2 newPose = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        if (Vector2.Distance(Player.position, rb.position)>=6 && Vector2.Distance(Player.position, rb.position)<=10 && walktime>=3)
        {
            animator.SetTrigger("JumpAttack");
        }else if (Vector2.Distance(Player.position, rb.position) <= 6 && walktime >= 3)
        {
            animator.SetTrigger("SpinAttack");
        }
        else
        {
            rb.MovePosition(newPose);
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("SpinAttack");
        animator.ResetTrigger("JumpAttack");
    }
}
