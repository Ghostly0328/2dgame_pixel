using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireboll : MonoBehaviour
{
    private float speed=1000;
    private float face=1;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (CharactorChangeCam.main.transform.localScale.x < 0)
        {
            face = -1;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(face*speed * Time.deltaTime,0);
        Destroy(gameObject, 0.8f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            PlayerScript.isColliding = true;
            collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
            Destroy(gameObject,0.02f);
        }
    }
}
