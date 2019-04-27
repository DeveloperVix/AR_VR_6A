using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="interactions/Image",fileName ="Image")]
public class interactivo_imagen : interactivo
{
    GameObject tempobj;

    public override void ejecutarinteraccion(GameObject obj)
    {
        Debug.Log("muestra la imagen");
        tempobj = obj;
        obj.SetActive(true);
    }

    public override void detenerejecucion()
    {
        Debug.Log("desactiva la imagen");
        tempobj.SetActive(false);
        tempobj = null;
    }
}
