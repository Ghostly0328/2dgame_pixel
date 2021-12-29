using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuRun : MonoBehaviour
{
    private Rigidbody2D Rb;
    public float Speed;
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rb.velocity = new Vector2(Speed * Time.deltaTime, Rb.velocity.y);//* Time.deltaTime
        if(gameObject.transform.position.x>700)
            SceneManager.LoadScene("Menu");
    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Class");
    }
}
