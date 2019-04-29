using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/CambiaColor", fileName = "CambiaColor")]

public class CambiaColor : Interactive
{
    public Material normal;
    public Material selected;
    MeshRenderer r;

    public override void DejaDeEjecutar(GameObject obj)
    {
        //r = obj.GetComponent<MeshRenderer>();
        r.material = normal;
        Debug.Log("Color normal");
    }

    public override void Ejecutar(GameObject obj)
    {
        r = obj.GetComponent<MeshRenderer>();
        r.material = selected;
        Debug.Log("Cambiando color");
    }

}
