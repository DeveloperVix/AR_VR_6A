using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotCubo : MonoBehaviour
{
    public Transform OBJ;
    bool rotarsi;
    public float vel;
    void Start()
    {
        OBJ = transform;
    }



    private void Update()
    {

        
        if (rotarsi)
        {
            OBJ.transform.Rotate(0,vel,0);
        }
        else
        {
            rotarsi = false;
        }
    }



    public void pointEnter()
    {
        rotarsi = true;
    }
    public void pointExit()
    {
        rotarsi = false;
    }
}