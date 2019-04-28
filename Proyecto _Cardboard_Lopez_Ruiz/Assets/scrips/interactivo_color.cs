using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "interactions/color", fileName = "color")]
public class interactivo_color : interactivo
{
    GameObject objcolor;

    public override void ejecutarinteraccion(GameObject objparainteractuar)
    {
        objcolor = objparainteractuar;
        objcolor.GetComponent<Renderer>().material.color = Color.blue;
    }
    public override void detenerejecucion()
    {
        objcolor.GetComponent<Renderer>().material.color = Color.red;
        objcolor = null;
    }
}
