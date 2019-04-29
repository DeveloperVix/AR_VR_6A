using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteractives : MonoBehaviour, Interface
{
    public Interactive[] estados; //Arreglo de estados de scriptables objects

    public GameObject[] obj;      //Arreglo de objetos

    delegate void EjecutarUpdate(GameObject obj); //Variable de tipo delegado que nos permitira ejecutar los metodos de los scriptables objetcs en un Update

    EjecutarUpdate cuboActual; //Variable tipo metodo EjercutarUpdate

    int num = 0;
    public void Look()
    {
        for (int i = 0; i < estados.Length; i++)
        {
            if (estados[i].interaccion == Interactive.TipoInteractivo.RotarObjeto)
            {
                num = 1;
                cuboActual = estados[i].Ejecutar;
                
                //Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactive.TipoInteractivo.ReproduceAudio)
            {
                estados[i].Ejecutar(obj[0]);
                
                //Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactive.TipoInteractivo.CambiarColor)
            {
                estados[i].Ejecutar(obj[2]);
                //Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactive.TipoInteractivo.MostrarTexto)
            {
                estados[i].Ejecutar(obj[1]);
                //Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactive.TipoInteractivo.Particulas)
            {

                estados[i].Ejecutar(obj[3]);

                
            }
        }
    }

    public void NoLook()
    {
        for (int i = 0; i < estados.Length; i++)
        {
            if (estados[i].interaccion == Interactive.TipoInteractivo.RotarObjeto)
            {
                num = 1;
                cuboActual = estados[i].DejaDeEjecutar;
                
                //Debug.Log(estados[i]);
            }

            if (estados[i].interaccion == Interactive.TipoInteractivo.ReproduceAudio)
            {
                estados[i].DejaDeEjecutar(obj[0]);
                //Debug.Log(estados[i]);
            }

            if (estados[i].interaccion == Interactive.TipoInteractivo.CambiarColor)
            {
                estados[i].DejaDeEjecutar(obj[2]);
                //Debug.Log(estados[i]);
            }

            if (estados[i].interaccion == Interactive.TipoInteractivo.MostrarTexto)
            {
                estados[i].DejaDeEjecutar(obj[1]);
                //Debug.Log(estados[i]);
            }
            if (estados[i].interaccion == Interactive.TipoInteractivo.Particulas)
            {
                
                estados[i].DejaDeEjecutar(obj[3]);
                //Debug.Log(estados[i]);
            }

        }
        cuboActual = null;
    }

    public void Update()
    {
        if (cuboActual != null)
        {

                cuboActual(obj[2]);

        }
    }


}
