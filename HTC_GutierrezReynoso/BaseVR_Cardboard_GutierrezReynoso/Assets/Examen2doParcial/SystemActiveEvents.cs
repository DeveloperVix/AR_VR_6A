using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemActiveEvents : MonoBehaviour
{
    /*  Este sistema nos servira para mostrar en momentos en especifico del cierto tipos de elementos como:
        -Texto
        -Imagenes
        -Señales o pistas que tendrán un color en especifico
     */

    //Definir un singleton para que podamos acceder desde otros scripts a los metodos publicos de este

    //Definir los colores que se le podrán asignar a los sprites
    public Material ColorBlue, ColorRed, ColorYellow, ColorGreen;
    //Definir los sprtes que serán las diferentes señales o pistas
    public Sprite SeeIcon, ReadIcon, MoveIcon;
    //La imagen en el UI que va a mostrar la retroalimentación de las señasl o pistas
    public GameObject imageSign, imageClue;
    //El texto en la UI donde pondremos el texto
    
	//0 = rigth, 1 = left

    // Use this for initialization
    void Start () 
	{
	
	}

    //Metodo publico para mostrar texto, recibe de parametro el texto a mostrar
    public void ShowText(GameObject text)
    {
        text.enable = true;
    }
        
    //Metodo para mostrar la imagen
    public void ShowImage(GameObject image)
    {
        image = imageClue;
        image.enable = true;
    }
        //Mostrar la imagen
        //Asignar la imagen
        //Asignarle el color
    
    public void DeactivatedGameObject(GameObject obj)
    {
        
    }
    //Metodo publico para dejar de mostrar los elementos, sea texto o imagen
        //Pasado cierto tiempo
            //Desactivar los elementos
}
