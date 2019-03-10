using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCube : MonoBehaviour
{
    //Rigidbody rb;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    public void OnClickW()
    {
        transform.Translate(Vector3.forward * 0.05f);
    }

    public void OnClickA()
    {
        transform.Translate(Vector3.left * 0.05f);
    }

    public void OnClickD()
    {
        transform.Translate(Vector3.right * 0.05f);
    }

    public void OnClickS()
    {
        transform.Translate(Vector3.forward * -0.05f);
    }
}
