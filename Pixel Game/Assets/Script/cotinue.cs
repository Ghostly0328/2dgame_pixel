using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cotinue : MonoBehaviour
{
    private void FixedUpdate()
    {
        if(Input.GetMouseButton(1) || Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Class");
        }
    }
}
