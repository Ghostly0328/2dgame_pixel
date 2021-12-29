using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies" && !PlayerScript.isColliding)
        {
            PlayerScript.isColliding = true;
            collision.gameObject.GetComponent<Enemy>().TakeDamage(Player.gameObject.GetComponent<PlayerScript>().PlayerDamage);
        }
    }
}
