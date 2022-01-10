using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginText : MonoBehaviour
{
    public Text maintext,Heart;
    private float countTime=0;
    void Start()
    {
        StaticCharactor.health = 10; //設定初始血量
        //檢查是否沒生命
        Invoke("BeginCheckLive",1.5f);
        maintext.text = "WORLD " + SceneManager.GetActiveScene().name;
        Heart.text = "X " + StaticCharactor.lastheart;
        Time.timeScale = 0;
    }
    void Update()
    {
        countTime += Time.fixedDeltaTime;
        if(countTime > 2f)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
    private void BeginCheckLive()
    {
        if (StaticCharactor.lastheart <= 0)
        {
            SceneManager.LoadScene("Class");
        }
    }
}
