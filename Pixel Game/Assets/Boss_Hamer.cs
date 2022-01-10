using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Boss_Hamer : Enemy
{
    public bool isFlipped = false;
    public Rigidbody2D Rb;
    public void Start()
    {
        base.Start();
        Rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if (health <= 0)
        {
            EnemyDead();
        }
        else if (health <= 100)
        {
            GetComponent<Animator>().SetTrigger("IsEnrage");
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > Player.transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < Player.transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    public void EnemyDead()
    {
        GetComponent<Animator>().SetTrigger("Dead");

    }
    public void BossDeadScore()
    {
        PlayerPrefs.SetInt("2-2", 3);
        SceneManager.LoadScene("Class");
    }
    public void JumpAtcChangePosition()
    {
        if (isFlipped)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x  +8.1f, gameObject.transform.position.y);

        }
        else
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 8.1f, gameObject.transform.position.y);
        }
    }
    public void SpinAtcChangePosition()
    {
        if (isFlipped)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 2.6f, gameObject.transform.position.y);

        }
        else
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 2.6f, gameObject.transform.position.y);
        }
    }
    public void DashChangePosition()
    {
        if (!isFlipped)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x -4f, gameObject.transform.position.y);

        }
        else
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x +4f, gameObject.transform.position.y);
        }
    }
}
