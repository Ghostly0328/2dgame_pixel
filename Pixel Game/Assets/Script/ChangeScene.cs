using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private string level;
    private void Start()
    {
        level = gameObject.name;
    }
    public void btnchangescene()
    {
        SceneManager.LoadScene(level);
    }
}
