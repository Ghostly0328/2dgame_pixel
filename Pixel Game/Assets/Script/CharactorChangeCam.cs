using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharactorChangeCam : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    public GameObject player, wizard;
    public static GameObject main;
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        if (StaticCharactor.charactor == 0)
        {
            player.SetActive(true);
            vcam.Follow = player.GetComponent<Transform>();
            main = player;
        }
        if (StaticCharactor.charactor == 1)
        {
            wizard.SetActive(true);
            vcam.Follow = wizard.GetComponent<Transform>();
            main = wizard;
        }
    }
}
