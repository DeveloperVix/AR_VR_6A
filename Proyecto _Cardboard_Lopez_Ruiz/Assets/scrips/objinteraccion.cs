using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objinteraccion : MonoBehaviour, interact
{
    public interactivo[] interacciones;

    delegate void ejecutarupdate(GameObject obj);

    ejecutarupdate ejecucionactual;

    public GameObject[] objinteraction;


    public void LookOnMe()
    {
        for (int i =0; i<interacciones.Length; i++)
        {
            if (interacciones[i].interaccionactual == interactivo.tipodeinteraccion.rotar)
            {
                ejecucionactual = interacciones[i].ejecutarinteraccion;
            }
            else
            {
                interacciones[i].ejecutarinteraccion(objinteraction[i]);
            }
        }
    }

    public void NoLookOnMe()
    {
        for (int i = 0; i<interacciones.Length; i++)
        {
            interacciones[i].detenerejecucion();
        }
        ejecucionactual = null;
    }

    private void Update()
    {
        if (ejecucionactual != null)
        {
            ejecucionactual(objinteraction[0]);
        }
    }
}
