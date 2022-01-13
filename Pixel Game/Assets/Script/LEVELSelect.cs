using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEVELSelect : MonoBehaviour
{
    public GameObject levelSelectPanel;
    public Button[] levelSelectButtons;
    public int unlockedlevelindex,testlevelindex=0;
    public string[] LevelNum;
    void Start()
    {
        levelSelectButtons = new Button[levelSelectPanel.transform.childCount];
        LevelNum = new string[] { "1-1", "1-2", "1-3", "2-1", "2-2", "2-3" };
        for (int i = 0; i < levelSelectButtons.Length ; i++)
        {
            if(PlayerPrefs.GetInt(LevelNum[i]) ==1 || PlayerPrefs.GetInt(LevelNum[i]) == 2 || PlayerPrefs.GetInt(LevelNum[i]) == 3)
            {
                testlevelindex += 1;
            }
        }
        PlayerPrefs.SetInt("unlockedLevelIndex", testlevelindex);
        unlockedlevelindex = PlayerPrefs.GetInt("unlockedLevelIndex");
        for (int i = 0; i < levelSelectPanel.transform.childCount; i++)
        {
            levelSelectButtons[i] = levelSelectPanel.transform.GetChild(i).GetComponent<Button>();
        }
        for (int i = 0; i < levelSelectButtons.Length; i++)
        {
            levelSelectButtons[i].interactable = false;
            levelSelectPanel.transform.GetChild(i).GetComponent<Animator>().SetInteger("STAR", -1);
        }
        for (int i = 0; i < unlockedlevelindex + 1; i++)
        {
            levelSelectButtons[i].interactable = true;
            levelSelectPanel.transform.GetChild(i).GetComponent<Animator>().SetInteger("STAR",0);
        }
        for (int i = 0; i < unlockedlevelindex + 1; i++)
        {
            levelSelectPanel.transform.GetChild(i).GetComponent<Animator>().SetInteger("STAR", PlayerPrefs.GetInt(LevelNum[i]));
        }
        StaticCharactor.lastheart = 3; //SetStartLife
    }
}
