using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBar : MonoBehaviour
{
    private Image Enemyheal;
    public static float num,max;
    void Start()
    {
        Enemyheal = GetComponent<Image>();
        num = max;
    }
    void Update()
    {
        Enemyheal.fillAmount = num / max;
    }
}
