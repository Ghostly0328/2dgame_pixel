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
        Player = CharactorChangeCam.main;
    }
    void FixedUpdate()
    {
        Health.fillAmount = StaticCharactor.health / HealthMax;
    }
}
