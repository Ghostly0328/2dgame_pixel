using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPointDestory : MonoBehaviour
{
    public float DestoryTime;
    void Start()
    {
        Destroy(gameObject, DestoryTime);
    }
}
