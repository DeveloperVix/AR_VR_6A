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
    public GameObject texto, imagen_gameobject;
    public static SystemActiveEvents instance;
    //Definir un singleton para que podamos acceder desde otros scripts a los metodos publicos de este

    //Definir los colores que se le podrán asignar a los sprites

    //Definir los sprtes que serán las diferentes señales o pistas
    public string textostring = "esto es un texto loko", textostring2 = "ayuda";
    //La imagen en el UI que va a mostrar la retroalimentación de las señasl o pistas

    //El texto en la UI donde pondremos el texto


    // Use this for initialization
    void Start () 
	{
	
	}

    public void mostrar_texto(Text textoprov)
    {
        texto.gameObject.SetActive(true);
        texto.GetComponent<Text>().text = textostring;
    }
    public void imagen()
    {
        imagen_gameobject.SetActive(true);
    }
    public void dejar__mostrarlo()
    {
        StartCoroutine("hola");
    }
    public void cambiar_colores()
    {
        texto.GetComponent<Text>().text = textostring2;
        imagen_gameobject.GetComponent<Image>().color = Color.blue;
        texto.GetComponent<Text>().color = Color.blue;
    }
    public void cambiar_colores2()
    {
        imagen_gameobject.GetComponent<Image>().color = Color.red;
        texto.GetComponent<Text>().color = Color.red;
    }

    IEnumerator hola()
    {
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(false);
        imagen_gameobject.SetActive(false);
    }

    //Metodo publico para mostrar texto, recibe de parametro el texto a mostrar
    //Mostrar el texto
    //Asignar texto

    //Metodo para mostrar la imagen
    //Mostrar la imagen
    //Asignar la imagen
    //Asignarle el color

    //Metodo publico para dejar de mostrar los elementos, sea texto o imagen
    //Pasado cierto tiempo
    //Desactivar los elementos
}
