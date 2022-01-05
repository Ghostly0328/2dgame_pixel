using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndZone : MonoBehaviour
{
    private float coin, time, zerocoin=0, zerotime=0;
    private bool coinend=false,timeend=false;
    public float coinupspeed, timeupspeed, levelcoinlimit, leveltimelimit;
    public Text cointext, timetext;
    public Animator anim;
    private int starcount = 0,PkStar;
    public GameObject activeme;
    private string SceneName;
    private void Start()
    {
        coin = CoinCount.Coin;
        time = CoinCount.totaltimecount;
        if (time <= leveltimelimit) starcount += 1;
        if (coin >= levelcoinlimit) starcount += 1;
        SceneName = SceneManager.GetActiveScene().name;
    }
    private void FixedUpdate()
    {
        if (coin > zerocoin)
        {
            zerocoin += coinupspeed;
        }
        else coinend = true;
        if (time > zerotime && coinend == true)
        {
            zerotime += timeupspeed;
        }else if(time <= zerotime && coinend == true) timeend = true;
        cointext.text = zerocoin.ToString();
        timetext.text = zerotime.ToString();
        if(timeend == true)
        {
            anim.SetInteger("star", starcount + 1);
            activeme.SetActive(true);
            PkStar = PlayerPrefs.GetInt(SceneName);
            if(PkStar < starcount + 1)
            {
                PlayerPrefs.SetInt(SceneName, starcount + 1);
            }
        }
    }
}
