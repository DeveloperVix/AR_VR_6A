using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteractivos : MonoBehaviour
{
    public Interactivo[] estados;

    public GameObject[] obj;

    delegate void EjecutarUpdate(GameObject obj); //

    EjecutarUpdate cuboActual;



    public void Look()
    {
        for (int i = 0; i < estados.Length; i++)
        {
            if (estados[i].interaccion == Interactivo.TipoInteractivo.Rotar)
            {
                cuboActual = estados[i].Ejecutar;
                Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactivo.TipoInteractivo.ReproduceAudio)
            {

                estados[i].Ejecutar(obj[1]);
                Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactivo.TipoInteractivo.Particulas)
            {
                estados[i].Ejecutar(obj[2]);
                Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactivo.TipoInteractivo.EnsenarTexto)
            {
                estados[i].Ejecutar(obj[0]);
                Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactivo.TipoInteractivo.CambiarColor)
            {
                estados[i].Ejecutar(obj[0]);
                Debug.Log(estados[i]);
            }
        }
    }

    public void NoLook()
    {
        Debug.LogWarning("saliste");
        for (int i = 0; i < estados.Length; i++)
        {
            if (estados[i].interaccion == Interactivo.TipoInteractivo.Rotar)
            {
                cuboActual = estados[i].Esperando;
                //Debug.Log(estados[i]);
            }

            if (estados[i].interaccion == Interactivo.TipoInteractivo.ReproduceAudio)
            {
                Debug.LogWarning("paro musica");
                estados[i].Esperando(obj[1]);
                //Debug.Log(estados[i]);
            }

            if (estados[i].interaccion == Interactivo.TipoInteractivo.CambiarColor)
            {
                estados[i].Esperando(obj[0]);
            }

            if (estados[i].interaccion == Interactivo.TipoInteractivo.EnsenarTexto)
            {
                estados[i].Esperando(obj[3]);
                //Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactivo.TipoInteractivo.Particulas)
            {
                estados[i].Esperando(obj[2]);
                Debug.Log(estados[i]);
            }


        }
        cuboActual = null;
    }

    public void Update()
    {//  Para ejecutar el delegado, preguntamos sino es nulo
        if (cuboActual != null)
        {
            //Aqui se se esta mandando llamar el delegado como metodo, tenemos que mandarle el parametro del tipo GameObject, del arreglo de objetos
            //necesitamos saber cual
            cuboActual(obj[0]);
        }
    }
}
