using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class buttonkeepdown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float PressDownTimer; //���U�X��Ĳ�o
    private bool PressDown; //���U
    public UnityEvent onLongClick; //�}��InspectorĲ�o�ƥ�
    [SerializeField]
    public float HoldTime;
    //���U���s
    public void OnPointerDown(PointerEventData eventData)
    {
        PressDown = true;
        PlayerWizard.abuttondown = true;
        //Debug.Log("PressDown");
    }
    //���s�u�_
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerWizard.abuttondown = false;
        //Debug.Log("PressUp");
    }
}
