using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/Rotar", fileName = "Rotar")]

public class Rotar : Interactive
{
    public float rotationSpeed;
    public float turnSpeed = 100;

    public override void DejaDeEjecutar(GameObject obj)
    {
        Debug.Log("Deja de rotar");
    }

    public override void Ejecutar(GameObject obj)
    {
        obj.transform.Rotate(new Vector3(rotationSpeed, rotationSpeed, rotationSpeed) * Time.deltaTime);
        Debug.Log("Rotando");
    }

    /*public void Update()
    {
        if (rotando == true)
        {
            cubo.transform.Rotate(new Vector3(rotationSpeed, rotationSpeed, rotationSpeed) * Time.deltaTime);
        }

        if (rotando == false)
        {
            cubo.transform.Rotate(new Vector3(0f, 0f, 0f) * Time.deltaTime);
        }
    }*/
}
