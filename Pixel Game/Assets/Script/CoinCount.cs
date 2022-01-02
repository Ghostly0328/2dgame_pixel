using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    static public int Coin;
    static public float totaltimecount = 0;
    private Text count;
    private void Start()
    {
        Coin = 0;
        count = GetComponent<Text>();
    }
    void Update()
    {
        totaltimecount += Time.deltaTime;
        count.text = Coin.ToString(); 
    }
}
