using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginText : MonoBehaviour
{
    public Text maintext,Heart;
    private static float countTime, _lastUpdate;
    public GameObject nongameover, gameover;
    private bool sceneclass;
    void Start()
    {
        Time.timeScale = 0;// Stop Time
        StaticCharactor.health = 10; //set ini health

        //set start word
        maintext.text = "WORLD " + SceneManager.GetActiveScene().name;
        Heart.text = "X " + StaticCharactor.lastheart;
        //setActiveTime
        _lastUpdate = Time.realtimeSinceStartup;
        gameover.SetActive(false);
        BeginCheckLive();
        countTime = 0;
    }
    void Update()
    {
        //CountTime
        countTime += Time.realtimeSinceStartup - _lastUpdate;
        if (countTime > 3f)
        {
            Time.timeScale = 1;
            if (sceneclass)
            {
                SceneManager.LoadScene("Class");
            }
            else
            {
                Destroy(gameObject);
            }
        }
        _lastUpdate = Time.realtimeSinceStartup;
    }
    private void BeginCheckLive()
    {
        if (StaticCharactor.lastheart <= 0)
        {
            nongameover.SetActive(false);
            gameover.SetActive(true);
            sceneclass = true;
        }
    }
}
