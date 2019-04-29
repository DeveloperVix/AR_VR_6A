using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interaccion/Rotar", menuName = "Rotar")]
public class InteractivoRotar : MenuInteractivo
{
    public int velocidad = 5;

    public override void DetenerAccion()
    {
        Debug.Log("Detener rotacion");
    }

    public override void Ejecutar(GameObject obj)
    {
        obj.transform.Rotate(Vector3.up * Time.deltaTime * velocidad);
    }
}
