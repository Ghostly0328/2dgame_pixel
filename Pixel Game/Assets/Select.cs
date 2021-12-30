using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public float char_num=0;
    public GameObject a, b, c;
    private void Update()
    {
        if (char_num == 1)
        {
            gameObject.transform.localPosition = new Vector2(280, gameObject.transform.localPosition.y);
        }
        if (char_num == 0)
        {
            gameObject.transform.localPosition = new Vector2(0, gameObject.transform.localPosition.y);
        }
        if (char_num == -1)
        {
            gameObject.transform.localPosition = new Vector2(-300, gameObject.transform.localPosition.y);
        }
    }
    public void right()
    {
        char_num += 1;
        if (char_num >= 1) char_num = 1;
    }
    public void left()
    {
        char_num -= 1;
        if (char_num <= -1) char_num = -1;
    }
}
