using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    static public int Coin;
    static public float totaltimecount;
    private static AudioSource coinsound;
    private Text count;
    private void Start()
    {
        Coin = 0;
        totaltimecount = 0;
        count = GetComponent<Text>();
        coinsound = GetComponent<AudioSource>();

    }
    void Update()
    {
        totaltimecount += Time.deltaTime;
        count.text = Coin.ToString(); 
    }
    public static void coinsoundplay()
    {
        coinsound.Play();
    }
}
