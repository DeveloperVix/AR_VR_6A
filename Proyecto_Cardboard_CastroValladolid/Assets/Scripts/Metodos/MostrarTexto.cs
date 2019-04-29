using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/MostrarTexto", fileName = "MostrarTexto")]

public class MostrarTexto : Interactive
{
    MeshRenderer r;

    public override void DejaDeEjecutar(GameObject obj)
    {
        
        r.enabled = false;
    }

    public override void Ejecutar(GameObject obj)
    {
        r = obj.GetComponent<MeshRenderer>();
        r.enabled = true;
        Debug.Log("Mostrando Texto");
    }
}
