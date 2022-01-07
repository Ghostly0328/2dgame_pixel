using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMare : Enemy
{
    private Rigidbody2D rb;
    public Transform left, right;
    private Animator anim;
    public LayerMask ground;
    public float speed;
    private float leftx, rightx;
    private BoxCollider2D col;
    private bool faceleft = true;
    public bool revurse;
    public GameObject Coin;
    public void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        leftx = left.position.x;
        rightx = right.position.x;
        faceleft = !revurse;
        if (revurse)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    public void Update()
    {
        if (health <= 0)
        {
            Instantiate(Coin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            gameObject.SetActive(false);
        }
        Movement();
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
                rb.velocity = new Vector2(-speed, 0);
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
                rb.velocity = new Vector2(+speed, 0);
            }
        }
    }
}
