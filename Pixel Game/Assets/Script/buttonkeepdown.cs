using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class buttonkeepdown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float PressDownTimer; //按下幾秒觸發
    private bool PressDown; //按下
    public UnityEvent onLongClick; //開啟Inspector觸發事件
    [SerializeField]
    public float HoldTime;
    //按下按鈕
    public void OnPointerDown(PointerEventData eventData)
    {
        PressDown = true;
        PlayerWizard.abuttondown = true;
        //Debug.Log("PressDown");
    }
    //按鈕彈起
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerWizard.abuttondown = false;
        //Debug.Log("PressUp");
    }
}
