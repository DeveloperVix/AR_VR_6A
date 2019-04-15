using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform cubo;
    public float rotationSpeed;
    public bool rotando = false;

    public void Start()
    {
        cubo = GetComponent<Transform>();
    }

    public void Update()
    {
        if (rotando == true)
        {
            cubo.transform.Rotate(new Vector3(rotationSpeed, rotationSpeed, rotationSpeed) * Time.deltaTime);
        }

        if (rotando == false)
        {
            cubo.transform.Rotate(new Vector3(0f, 0f, 0f) * Time.deltaTime);
        }
    }

    public void OnPointerEnter2()
    {
        Debug.Log("Rotando");
        rotando = true;
    }

    public void OnPointerExit2()
    {
        Debug.Log("Pausando Rotacion");
        rotando = false;
    }
}
