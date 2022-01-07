using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginText : MonoBehaviour
{
    public Text maintext,Heart;
    void Start()
    {
        StaticCharactor.health = 10; //�]�w��l��q
        //�ˬd�O�_�S�ͩR
        Invoke("BeginCheckLive",1.5f);
        maintext.text = "WORLD " + SceneManager.GetActiveScene().name;
        Heart.text = "X " + StaticCharactor.lastheart;
        Destroy(gameObject, 2);//�����}�Y����
    }
    private void BeginCheckLive()
    {
        if (StaticCharactor.lastheart <= 0)
        {
            SceneManager.LoadScene("Class");
        }
    }
}
