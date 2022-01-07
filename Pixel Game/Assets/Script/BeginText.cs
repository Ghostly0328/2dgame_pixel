using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginText : MonoBehaviour
{
    public Text maintext,Heart;
    void Start()
    {
        StaticCharactor.health = 10; //設定初始血量
        //檢查是否沒生命
        Invoke("BeginCheckLive",1.5f);
        maintext.text = "WORLD " + SceneManager.GetActiveScene().name;
        Heart.text = "X " + StaticCharactor.lastheart;
        Destroy(gameObject, 2);//關閉開頭頁面
    }
    private void BeginCheckLive()
    {
        if (StaticCharactor.lastheart <= 0)
        {
            SceneManager.LoadScene("Class");
        }
    }
}
