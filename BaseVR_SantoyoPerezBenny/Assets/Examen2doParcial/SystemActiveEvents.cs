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
    public static SystemActiveEvents instance;
    //Definir un singleton para que podamos acceder desde otros scripts a los metodos publicos de este

    //Definir los colores que se le podrán asignar a los sprites
    public MeshRenderer rojo, verde, amarillo;

    //Definir los sprtes que serán las diferentes señales o pistas
    public GameObject Señal1;
    public GameObject Señal2;

    //La imagen en el UI que va a mostrar la retroalimentación de las señasl o pistas
    public Image imagen;

    //El texto en la UI donde pondremos el texto
    public Text texto;
    
    void Start () 
	{
	    
	}

    //Metodo publico para mostrar texto, recibe de parametro el texto a mostrar
        //Mostrar el texto
        //Asignar texto

    public void CubeText(Text text)
    {
        text.gameObject.SetActive(true);
        text.color = Color.green;
        text.text = "CUBO";
    }

    public void CubeTextOFF(Text text)
    {
        StartCoroutine("CUBETEXTOoff");
    }

    IEnumerator CUBETEXTOoff()
    {
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(false);
        texto.text = "TEXT";
        
    }

    public void MostrarTextoAzul(Text text)
    {
        texto.gameObject.SetActive(true);
        texto.color = Color.blue;
    }

    public void DejarMostrarTextoAzul(Text text)
    {
        StartCoroutine("SalidaVistaTextoAzul");
    }

    IEnumerator SalidaVistaTextoAzul()
    {
        yield return new WaitForSeconds (3f);
        texto.gameObject.SetActive(false);

    }

    public void MostrarTextoAmarillo(Text text)
    {
        texto.gameObject.SetActive(true);
        texto.color = Color.yellow;
    }

    public void DejarMostrarTextoAmarillo(Text text)
    {
        StartCoroutine("SalidaVistaTextoAmarillo");
    }

    IEnumerator SalidaVistaTextoAmarillo()
    {
        yield return new WaitForSeconds(3f);
        texto.gameObject.SetActive(false);
    }

    //Metodo para mostrar la imagen
    //Mostrar la imagen
    //Asignar la imagen
    //Asignarle el color
    public void MostrarImagenAzul()
    {
        imagen.gameObject.SetActive(true);
        imagen.color = Color.blue;
    }

    public void DejarMostrarImagenAzul()
    {
        StartCoroutine("SalidaVistaImagenAzul");
        
    }

    IEnumerator SalidaVistaImagenAzul()
    {
        yield return new WaitForSeconds(3f);
        imagen.gameObject.SetActive(false);
        imagen.color = Color.blue;
    }

    public void MostrarImagenAmarilla()
    {
        imagen.gameObject.SetActive(true);
        imagen.color = Color.yellow;
    }

    IEnumerator SalidaVistaImagenAmarilla()
    {
        yield return new WaitForSeconds(3f);
        imagen.gameObject.SetActive(false);
    }

    public void DejarMostrarImagenAmarila()
    {
        StartCoroutine("SalidaVistaImagenAmarilla");
    }

    //Metodo publico para dejar de mostrar los elementos, sea texto o imagen
    //Pasado cierto tiempo
    //Desactivar los elementos
    public void MostrarTextoImagen()
    {

    }
}
