using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Run : StateMachineBehaviour
{
    public float speed;
    public float attackRange;
    BossHero boss;
    Transform Player;
    Rigidbody2D rb;
    static public float AttackNum=0;
    
    override public void OnStateEnter(Animator animatior, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animatior.GetComponent<Rigidbody2D>();
        boss = animatior.GetComponent<BossHero>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(Player.position.x, -5.631421f);
        Vector2 newPose = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        if (AttackNum >= 3)
        {
            AttackNum = 0;
            rb.velocity = new Vector2(Mathf.Sign(Player.position.x - rb.position.x) *14, 9); //*Time.deltaTime
            animator.SetBool("Jump", true);
        }
        else if (Vector2.Distance(Player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }else
            rb.MovePosition(newPose);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
