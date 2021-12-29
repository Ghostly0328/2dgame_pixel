using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private static float HealthCurrent;
    public float HealthMax;
    private GameObject Player;
    public Image Health;
    void Start()
    {
        HealthCurrent = HealthMax;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Health.fillAmount = Player.GetComponent<PlayerScript>().PlayerHealth / HealthMax;
    }
}
