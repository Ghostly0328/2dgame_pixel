using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform Cam;
    public float MoveRate;
    private float StartPointX, StartPointY,Diffx;
    public bool LockY;
    public bool ReverseX;
    private float ReverseNum;
    void Start()
    {
        StartPointX = Cam.position.x;
        StartPointY = transform.position.y;
        if (ReverseX) ReverseNum = -1;
        else ReverseNum = 1;
    }

    void FixedUpdate()
    {
        Diffx = Cam.position.x - StartPointX;
        if (LockY)
        {
            transform.position = new Vector3(StartPointX + ReverseNum * Diffx * MoveRate, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(StartPointX + ReverseNum * Cam.position.x * MoveRate, StartPointY, transform.position.z);
        }
    }
}
