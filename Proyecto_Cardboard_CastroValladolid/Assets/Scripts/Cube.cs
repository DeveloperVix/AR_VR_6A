using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material normal;
    public Material selected;
    MeshRenderer r;

    bool isRotate = false;
    float rotacion = 10f;
    float turnSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotate == true)
        {
            DetectadoRotacion();
        }
        else
        {
            NoDetectadoRotacion();
        }
    }

    public void Detectado()
    {
        r.material = selected;
    }

    public void NoDetectado()
    {
        r.material = normal;
    }

    public void DetectadoRotacion()
    {
        isRotate = true;
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }

    public void NoDetectadoRotacion()
    {
        isRotate = false;
    }
}
