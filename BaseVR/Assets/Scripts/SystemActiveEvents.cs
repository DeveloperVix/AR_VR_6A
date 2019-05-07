using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SystemActiveEvents : MonoBehaviour
{
    /*  Este sistema nos servira para mostrar en momentos en especifico del cierto tipos de elementos como:
        -Texto
        -Imagenes
        -Señales o pistas que tendrán un color en especifico
     */
    //Definir un singleton para que podamos acceder desde otros scripts a los metodos publicos de este
    public static SystemActiveEvents intance;
    //Definir los colores que se le podrán asignar a los sprites
    public Color[] colores;
    //Definir los sprtes que serán las diferentes señales o pistas
    public Sprite[] sprits;
    public SpriteRenderer sprit;
    //La imagen en el UI que va a mostrar la retroalimentación de las señasl o pistas
    public Image[] señalesImages;
    //El texto en la UI donde pondremos el texto
    public TextMeshProUGUI[] TxtMP;
    // Use this for initialization
    void Start () 
	{
        TxtMP[0].text = "";
        Txt(0);
	}

    //Metodo publico para mostrar texto, recibe de parametro el texto a mostrar
    //Mostrar el texto
    //Asignar texto
    public void Txt(int op)
    {
        switch (op) {
            case 0:
                text();
                break;
    }
    }

    IEnumerator text()
    {
        TxtMP[0].text = "Bienvenido";
        yield return new WaitForSeconds(5);
        TxtMP[0].text = "Mira las Señales de imagen /n te mostraran cuando puedes /n realizar una accion";
        yield return new WaitForSeconds(6);
        TxtMP[0].text = "";
    }

    //Metodo para mostrar la imagen
        //Mostrar la imagen
        //Asignar la imagen
        //Asignarle el color
      public void imgAsignSprite(int opcion)
    {
        switch (opcion)
        {
            case 0:

                break;
        }
    }


    public void imgAsignColor(int op)
    {
        switch (op)
        {
            case 0:

                break;
        }
    }

    //Metodo publico para dejar de mostrar los elementos, sea texto o imagen
    //Pasado cierto tiempo
    //Desactivar los elementos
}
