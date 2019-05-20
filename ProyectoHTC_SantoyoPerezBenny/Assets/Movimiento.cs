using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Transform Head;
    public float speedMov;
    public Camera camera;

    void Start()
    {
        Head = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CameraFoward = camera.transform.forward;
        if(Input.GetKey(KeyCode.W))
        {
            Head.Translate(0, 0, -0.1f);
            //Head.LookAt(CameraFoward);
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                Head.Translate(0, 0, 0.1f);
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    Head.Translate(0.1f, 0, 0);
                }
                else
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        Head.Translate(-0.1f, 0,0);
                    }
                }
            }
        }
    }
}
