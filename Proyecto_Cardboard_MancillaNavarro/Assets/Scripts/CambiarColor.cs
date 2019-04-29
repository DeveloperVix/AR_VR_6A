using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/CambiarColor", fileName = "CambiarColor")]

public class CambiarColor : Interactivo
{
    public Material normal;
    public Material selected;
    MeshRenderer r;

    public override void Esperando(GameObject obj)
    {
        Debug.Log("Esperando");
        r.material = normal;
    }

    public override void Ejecutar(GameObject obj)
    {
        Debug.Log("Ejecutando");
        r = obj.GetComponent<MeshRenderer>();
        r.material = selected;
    }
}
