using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/Rotar", fileName = "Rotar")]

public class Rotar : Interactive
{

    public float turnSpeed = 100;

    public override void DejaDeEjecutar(GameObject obj)
    {
        Debug.Log("Deja de rotar");
    }

    public override void Ejecutar(GameObject obj)
    {
        obj.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        Debug.Log("Rotando");
    }
}
