using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    public MenuInteractivo[] interactivos;

    delegate void UpdateEjecutar(GameObject obj);

    UpdateEjecutar ejecucionActual;

    public GameObject[] objInteraccion;

    public void Mirando()
    {
        for(int i = 0; i < interactivos.Length; i++)
        {
            if(interactivos[i].currentInteraction == MenuInteractivo.TypeInteraction.color)
            {
                ejecucionActual = interactivos[i].Ejecutar;
            }
        }
    }

    public void YanoMiro()
    {
        for (int i = 0; i < interactivos.Length; i++)
        {
            interactivos[i].DetenerAccion();
        }

        ejecucionActual = null;
    }

    private void Update()
    {
        if(ejecucionActual != null)
        {
            ejecucionActual(objInteraccion[0]);
        }
    }
}
