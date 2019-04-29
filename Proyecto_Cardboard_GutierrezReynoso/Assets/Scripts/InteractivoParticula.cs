using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivoParticula : MenuInteractivo
{
    GameObject particula;

    public override void DetenerAccion()
    {
        Destroy(particula);
    }

    public override void Ejecutar(GameObject obj)
    {
        Instantiate(particula);
    }
    
}
