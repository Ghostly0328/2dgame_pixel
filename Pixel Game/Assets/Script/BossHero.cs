using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHero : Enemy
{
    private bool isDead;
    public bool isFlipped = false;
    public Rigidbody2D Rb;
    public Collider2D groundcheck;
    public LayerMask Ground;
    public void Start()
    {
        isDead = false;
        EnemyBar.max = health;
        base.Start();
        Rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        EnemyBar.num = health;
        if (health <= 0)
        {
            EnemyDead();
        }
        else if (health <= 30)
        {
            GetComponent<Animator>().SetBool("IsEnrage",true);
        }
        if (groundcheck.IsTouchingLayers(Ground))
        {
            gameObject.GetComponent<Animator>().SetBool("Fall", false);
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x >Player.transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x <Player.transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    public void EnemyDead()
    {
        if (isDead == false)
        {
            GetComponent<Animator>().SetTrigger("Dead");
        }
        isDead = true;
    }
    public void Attackplus1()
    {
        Hero_Run.AttackNum += 1;
    }
    public void BossDeadScore()
    {
        PlayerPrefs.SetInt("1-3", 3);
        SceneManager.LoadScene("Class");
    }
}
