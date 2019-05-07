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
    public static SystemActiveEvents Sistema;
    //Definir los colores que se le podrán asignar a los sprites
    public Color rojo, verde, naranja;
    //Definir los sprtes que serán las diferentes señales o pistas
    public Sprite sprite;
    //La imagen en el UI que va a mostrar la retroalimentación de las señasl o pistas
    public Image ImagenPos, ImageRes;
    //El texto en la UI donde pondremos el texto
    public Text TextoColocado;
	//0 = rigth, 1 = left

    //Metodo publico para mostrar texto, recibe de parametro el texto a mostrar
        //Mostrar el texto
        //Asignar texto
    public void Texto()
    {
        TextoColocado.gameObject.SetActive(true);
        TextoColocado.text = "Hola que hace";
    }
    //Metodo para mostrar la imagen
        //Mostrar la imagen
        //Asignar la imagen
        //Asignarle el color
    public void Imagen()
    {
        ImagenPos.gameObject.SetActive(true);
        ImagenPos.color = rojo;
        ImagenPos.sprite = sprite;
    }
    //Metodo publico para dejar de mostrar los elementos, sea texto o imagen
        //Pasado cierto tiempo
            //Desactivar los elementos
    public void Desactivar()
    {
        TextoColocado.gameObject.SetActive(false);
        ImagenPos.gameObject.SetActive(false);
    }
}