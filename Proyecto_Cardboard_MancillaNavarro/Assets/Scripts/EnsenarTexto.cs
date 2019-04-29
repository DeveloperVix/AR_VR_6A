using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/EnsenarTexto", fileName = "EnsenarTexto")]
public class EnsenarTexto : Interactivo
{
    MeshRenderer objImage;
    public override void Esperando(GameObject obj)
    {
        objImage = obj.GetComponent<MeshRenderer>();
        objImage.enabled = false;
        Debug.Log("imagen");
    }

    public override void Ejecutar(GameObject obj)
    {
        Debug.Log("Enseño texto");
        objImage.enabled = true;
    }
}
