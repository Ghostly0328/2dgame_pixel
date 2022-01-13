using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginText : MonoBehaviour
{
    public Text maintext,Heart;
    private static float countTime, _lastUpdate;
    public GameObject nongameover, gameover;
    private bool sceneclass;
    public AudioSource gameoversound,bgm;
    void Start()
    {
        StaticCharactor.health = 10; //設定初始血量
        //檢查是否沒生命
        Invoke("BeginCheckLive",1.5f);
        maintext.text = "WORLD " + SceneManager.GetActiveScene().name;
        Heart.text = "X " + StaticCharactor.lastheart;
        Time.timeScale = 0;
        countTime = 0;
        _lastUpdate = Time.realtimeSinceStartup;
        gameover.SetActive(false);
        BeginCheckLive();
        gameoversound = GetComponent<AudioSource>();
        bgm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }
    void Update()
    {
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
            //bgm.Stop();
            gameoversound.Play();
        }
    }
}
