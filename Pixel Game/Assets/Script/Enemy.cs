using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    private SpriteRenderer sr;
    private Color originalcolor;
    public float FlashTime;
    public GameObject BloodEffect,Player,wizard,sword;
    //public Animator Anim;
    public GameObject FloatPointBase;
    public void Start()
    {
        //Anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalcolor = sr.color;
        if (StaticCharactor.charactor == 0)
        {
            Player = sword;
        }
        if (StaticCharactor.charactor == 1)
        {
            Player = wizard;
        }
    }
    public void TakeDamage(float damage)
    {
        GameObject gb =Instantiate(FloatPointBase,new Vector3(transform.position.x, transform.position.y,0.1f), Quaternion.identity);
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
        health -= damage;
        FlashColor(FlashTime);
        Instantiate(BloodEffect, transform.position, Quaternion.identity);
    }
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        sr.color = originalcolor;
    }
    public void SentDamage(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies" && !PlayerScript.isColliding)
        {
            PlayerScript.isColliding = true;
            collision.gameObject.GetComponent<Enemy>().TakeDamage(10);
        }
    }
    public void PlayerTrigger(Collider2D other)
    {
        if(other.gameObject.tag=="Player" && PlayerScript.dashTimeLeft < 0.001f) //other.GetType().ToString()== "UnityEngine.CapsuleCollider2D"
        {
            CharactorChangeCam.main.SendMessage("PlayerGetDamage", damage);
        }
    }
}
