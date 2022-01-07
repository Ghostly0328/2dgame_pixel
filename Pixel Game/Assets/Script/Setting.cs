using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject SettingPanel;
    public void SettingOnClick()
    {
        Time.timeScale = 0;
        SettingPanel.SetActive(true);
    }
    public void CanelOnClick()
    {
        Time.timeScale = 1;
        SettingPanel.SetActive(false);
    }
    public void ExitToMemu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Class");
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
