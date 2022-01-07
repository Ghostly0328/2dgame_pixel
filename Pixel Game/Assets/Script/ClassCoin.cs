using UnityEngine;
using UnityEngine.UI;

public class ClassCoin : MonoBehaviour
{
    private string[] LevelNum;
    private int Coin;
    private Text count;
    private void Start()
    {
        LevelNum = new string[] { "1-1", "1-2", "1-3", "2-1", "2-2", "2-3" };
        count = GetComponent<Text>();
        for (int i = 0; i < 6; i++)
        {
            Coin += PlayerPrefs.GetInt(LevelNum[i] + "Coin");
        }
        count.text = "" + Coin;
    }
}

