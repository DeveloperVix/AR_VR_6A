using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SystemActiveEvents : MonoBehaviour
{
    public int espera = 1;
    public void poner = true;
    
   
    /*  Este sistema nos servira para mostrar en momentos en especifico del cierto tipos de elementos como:
        -Texto
        -Imagenes
        -Señales o pistas que tendrán un color en especifico
     */

    //Definir un singleton para que podamos acceder desde otros scripts a los metodos publicos de este

    //Definir los colores que se le podrán asignar a los sprites

    //Definir los sprtes que serán las diferentes señales o pistas
	
    //La imagen en el UI que va a mostrar la retroalimentación de las señasl o pistas

    //El texto en la UI donde pondremos el texto

	//0 = rigth, 1 = left

    // Use this for initialization
    void Start () 
	{
        quitarelementos();
        poner();
        imagen();
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

    public void imagen()
    {
        if (poner == true)
        {
            //instanciar los objetos
            async material = red;


        }
    }

    public void quitarelementos()
    {
        int esperar = espera+1;
        if (esperar >= 10)
        {
            poner = false;
        }
    }

    
}
