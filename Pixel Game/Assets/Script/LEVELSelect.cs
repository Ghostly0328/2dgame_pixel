using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEVELSelect : MonoBehaviour
{
    public GameObject levelSelectPanel;
    public Button[] levelSelectButtons;
    public int unlockedlevelindex;
    void Start()
    {
        unlockedlevelindex = PlayerPrefs.GetInt("unlockedLevelIndex");
        levelSelectButtons = new Button[levelSelectPanel.transform.childCount];
        for(int i = 0; i < levelSelectPanel.transform.childCount; i++)
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
        StaticCharactor.lastheart = 3;//設定生命值=3
    }
}
