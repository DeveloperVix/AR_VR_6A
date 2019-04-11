using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform cuboRot;
    bool rot = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rot)
        {
            cuboRot.Rotate(0, 0, 100 * Time.deltaTime);
        }
    }
    public void Rotation()
    {
        rot = true;
    }
    public void ExitRotation()
    {
        rot = false;
    }
}
