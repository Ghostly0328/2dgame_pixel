using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginText : MonoBehaviour
{
    public Text maintext,Heart;
    void Start()
    {
        if (StaticCharactor.lastheart <= 0)
        {
            SceneManager.LoadScene("Class");
        }//�ˬd�O�_�S�ͩR
        maintext.text = "WORLD " + SceneManager.GetActiveScene().name;
        Heart.text = "X " + StaticCharactor.lastheart;
        Destroy(gameObject, 2);//�����}�Y����
    }
}
