using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAdvice : MonoBehaviour
{

    public string message, sprite;
    

    public void Send()
    {
        if(message != "")
        {
            SystemActiveEvents.act.ShowText(message);
        }
        else
        {
            SystemActiveEvents.act.textFeedBack.transform.parent.gameObject.SetActive(false);
        }
        if(sprite != "")
        {
            SystemActiveEvents.act.ShowImage(sprite);
        }
        else
        {
            SystemActiveEvents.act.imageFeedback.gameObject.SetActive(false);
        }
        SystemActiveEvents.act.HideUIElements();
    }
}
