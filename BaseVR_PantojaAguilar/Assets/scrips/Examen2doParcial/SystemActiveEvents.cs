using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SystemActiveEvents : MonoBehaviour
{
    MeshRenderer mesRender;
    public Material[] mMatelia;
    public GameObject[] texto;
    public GameObject imgen;
    public bool[] estD;
    /*  Este sistema nos servira para mostrar en momentos en especifico del cierto tipos de elementos como:
        -Texto
        -Imagenes
        -Señales o pistas que tendrán un color en especifico
     */

    //Definir un singleton para que podamos acceder desde otros scripts a los metodos publicos de este
    public static PoolingManager sing;
    //Definir los colores que se le podrán asignar a los sprites

    //Definir los sprtes que serán las diferentes señales o pistas

    //La imagen en el UI que va a mostrar la retroalimentación de las señasl o pistas

    //El texto en la UI donde pondremos el texto

    //0 = rigth, 1 = left

    // Use this for initializatio
    // me esta dando un erros en el detector de colicion 
    void Start()
    {
        //en caso de que no esten activos la opcion de textos los desactiva 
        if (estD[0] == false)
        {
           texto[0].SetActive(false);
        }
        mesRender = GetComponent<MeshRenderer>();
    }
    public void text(){
        //Metodo publico para mostrar texto, recibe de parametro el texto a mostrar
        //Mostrar el texto
        //Asignar texto

        //intercabia textos
        texto[0].SetActive(false);
        texto[1].SetActive(true);
    }

    public void imagen()
    {
        //Metodo para mostrar la imagen
        //Mostrar la imagen
        //Asignar la imagen
        //Asignarle el color

        //activa una imgen y cambia el material de objeto para dar uan imprecion que cabieo de color la flecha
        imgen.SetActive(true);
        mesRender.material = mMatelia[1];
        
    }
    public void desac() {
        //Metodo publico para dejar de mostrar los elementos, sea texto o imagen
        //Pasado cierto tiempo
        //Desactivar los elementos
        if (estD[0] == true)
        {
            //texto[0].SetActive(true);
            texto[1].SetActive(false);
        }
        if (estD[1] == true)
        {
            imgen.SetActive(false);
            mesRender.material = mMatelia[0];
        }

    }
}
