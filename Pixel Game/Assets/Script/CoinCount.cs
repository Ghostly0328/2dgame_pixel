using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    static public int Coin;
    private Text count;
    private void Start()
    {
        count = GetComponent<Text>();
    }
    void Update()
    {
        count.text = Coin.ToString(); 
    }
}
