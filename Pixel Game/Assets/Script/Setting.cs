using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Setting : MonoBehaviour
{
    public static Setting Instance { get; private set; }
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float shakeTimer;
    public GameObject SettingPanel;
    private void Awake()
    {
        Instance = this;
        CinemachineVirtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
    }
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
    public void shakecamera(float intensity,float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                //TimerOver
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
