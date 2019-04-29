using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaccion/Color", fileName = "Color")]
public class InteractivoColor : MenuInteractivo
{
    GameObject objTem;

    public override void DetenerAccion()
    {
        objTem.GetComponent<MeshRenderer>().material.color = Color.blue;

    }

    public override void Ejecutar(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = Color.green;
        objTem = obj;
    }
}
