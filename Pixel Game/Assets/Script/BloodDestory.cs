using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDestory : MonoBehaviour
{
    public float BloodTime;
    void Start()
    {
        Destroy(gameObject, BloodTime);
    }
}
