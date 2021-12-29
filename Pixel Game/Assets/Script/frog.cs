using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : Enemy
{
    private Rigidbody2D rb;
    public Transform left, right;
    private Animator anim;
    public LayerMask ground;
    public float speed,jumpforce;
    private float leftx, rightx;
    private BoxCollider2D col;
    private bool faceleft = true;
    public void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        //transform.DetachChildren();
        leftx = left.position.x;
        rightx = right.position.x;
        //Destroy(left.gameObject);
        //Destroy(right.gameObject);
    }

    public void Update()
    {
        SwitchAnim();
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    void Movement()
    {
        if (faceleft)
        {
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                faceleft = false;
            }
            if (col.IsTouchingLayers(ground) && faceleft)
            {
                rb.velocity = new Vector2(-speed, jumpforce);
                anim.SetBool("jumping",true);
            }
            
            
        }
        else
        {
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                faceleft = true;
            }
            if (col.IsTouchingLayers(ground) && faceleft == false)
            {
                rb.velocity = new Vector2(+speed, jumpforce);
                anim.SetBool("jumping", true);
            }
        }
    }
    void SwitchAnim()
    {
        if(anim.GetBool("jumping"))
        {

            if (rb.velocity.y < 0.1f)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        if (col.IsTouchingLayers(ground) && anim.GetBool("falling"))
        {
            anim.SetBool("falling", false);
        }
    }
    public void AttackTrigger()
    {

    }
}
