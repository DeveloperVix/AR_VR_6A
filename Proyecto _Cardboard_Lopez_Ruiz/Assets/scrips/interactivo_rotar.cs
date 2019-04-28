using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "interactions/rotate",fileName ="rotate")]
public class interactivo_rotar : interactivo
{
    public int speed = 10;
    GameObject objetrotar;

    public override void ejecutarinteraccion(GameObject objparainteractuar)
    {
        objetrotar = objparainteractuar;
        objparainteractuar.transform.Rotate(1, 1, 1 * 2);
    }
    public override void detenerejecucion()
    {
        objetrotar.transform.Rotate(1 * 0, 1 * 0, 1 * 0);
        objetrotar = null;
    }
}
