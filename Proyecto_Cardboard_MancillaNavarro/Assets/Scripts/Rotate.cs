using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/Rotate", fileName = "Rotate")]

public class Rotate : Interactivo
{
    public float turnSpeed = 100;

    public override void Esperando(GameObject obj)
    {
        Debug.Log("Deja de rotar");
    }

    public override void Ejecutar(GameObject obj)
    {
        Debug.Log("Rotando");
        obj.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
    }
}
