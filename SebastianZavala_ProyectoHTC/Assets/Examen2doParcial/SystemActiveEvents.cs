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


    //Definir los colores que se le podrán asignar a los sprites
    public MeshRenderer MaterialChamber;
    

    public Material Material1, Material2, Material3, Material4;
    //Definir los sprites que serán las diferentes señales o pistas
    public GameObject signal1, signal2, signal3, signal4;
    //La imagen en el UI que va a mostrar la retroalimentación de las señasl o pistas
    public Image img1, img2, img3;
    //El texto en la UI donde pondremos el texto
    public Text text1, text2, text3;

	//0 = rigth, 1 = left

    // Use this for initialization
    void Start () 
	{
        MaterialChamber.GetComponent<MeshRenderer>();
        img1.GetComponent<Text>();

        TextChamber();
        ImageChameber();
        HidenChambers();
	
	}

    //Metodo publico para mostrar texto, recibe de parametro el texto a mostrar
    //Mostrar el texto
    //Asignar texto

    public void TextChamber()
    {
        text1.text = "Banana";
        text2.text = "Kurt Escopetas";
        text3.text = "Salmon Dance";
    }

    //Metodo para mostrar la imagen
    //Mostrar la imagen
    //Asignar la imagen
    //Asignarle el color

    public void ImageChameber()
    {

    }

    //Metodo publico para dejar de mostrar los elementos, sea texto o imagen
    //Pasado cierto tiempo
    //Desactivar los elementos

    public void HidenChambers()
    {
        
    }
   
}
