using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemActiveEvents : MonoBehaviour
{
    /*  Este sistema nos servira para mostrar en momentos en especifico del cierto tipos de elementos como:
        -Texto
        -Imagenes
        -Señales o pistas que tendrán un color en especifico
     */

    //Definir un singleton para que podamos acceder desde otros scripts a los metodos publicos de este
    public static SystemActiveEvents act;

    //Definir los colores que se le podrán asignar a los sprites
    public Color colorRed, colorGreen, colorYellow;

    //Definir los sprtes que serán las diferentes señales o pistas
    public Sprite sprNull, sprAdvice, sprInfo;

    //La imagen en el UI que va a mostrar la retroalimentación de las señasl o pistas
    public Image imageFeedback;

    //El texto en la UI donde pondremos el texto
    public Text textFeedBack;

    //0 = rigth, 1 = left

    Coroutine hideCo;

    // Use this for initialization
    void Start () 
	{
        act = this;
	}
    //Metodo publico para mostrar texto, recibe de parametro el texto a mostrar
    //Mostrar el texto
    //Asignar texto

    public void ShowText(string s)
    {
        textFeedBack.text = s;
        textFeedBack.transform.parent.gameObject.SetActive(true);
    }

    //Metodo para mostrar la imagen
    //Mostrar la imagen
    //Asignar la imagen
    //Asignarle el color
    public void ShowImage(string s)
    {
        Sprite spr = sprNull;
        Color color = Color.white;
        switch (s)
        {
            case "advice":
                spr = sprAdvice;
                color = colorRed;
                break;
            case "info":
                spr = sprInfo;
                color = colorYellow;
                break;
        }

        imageFeedback.sprite = spr;
        imageFeedback.color = color;
        imageFeedback.gameObject.SetActive(true);
    }

    //Metodo publico para dejar de mostrar los elementos, sea texto o imagen
    //Pasado cierto tiempo
    //Desactivar los elementos

    public float hideTime = 5f;

    public void HideUIElements()
    {
        if (hideCo != null)
        {
            StopCoroutine(hideCo);
            hideCo = null;
        }
        StartCoroutine(HideUIElementsCo());
    }

    IEnumerator HideUIElementsCo()
    {
        yield return new WaitForSeconds(hideTime);
        imageFeedback.gameObject.SetActive(false);
        textFeedBack.transform.parent.gameObject.SetActive(false);
        hideCo = null;
    }
}
