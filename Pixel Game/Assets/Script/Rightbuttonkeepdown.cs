using UnityEngine;
using UnityEngine.EventSystems;
public class Rightbuttonkeepdown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //«ö¤U«ö¶s
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerScript.horizontalmove = 1;
        PlayerScript.facedirection = 1;
        PlayerWizard.horizontalmove = 1;
        PlayerWizard.facedirection = 1;
        //Debug.Log("PressDown");
    }
    //«ö¶s¼u°_
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerScript.horizontalmove = 0;
        PlayerScript.facedirection = 0;
        PlayerWizard.horizontalmove = 0;
        PlayerWizard.facedirection = 0;
        //Debug.Log("PressUp");
    }
}
