using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsController : MonoBehaviour
{

    public Camera thisCamera;
    public Rigidbody cubePlayer;

    public float velZ = 10f; //Vertical
    public float velX = 10f; //Horizontal

    public bool upSense;
    public bool rightSense;
    public bool downSense;
    public bool leftSense;

    public new Vector3 mov;

    // Start is called before the first frame update
    void Awake()
    {
        if (upSense && !rightSense && !leftSense && !downSense) //Arriba
        {
            mov = new Vector3(0, velZ, 0);
        }
        else if (rightSense && !leftSense && !downSense && !upSense) //Derecha
        {
            mov = new Vector3(velX, 0, 0);
        }
        else if (leftSense && !rightSense && !downSense && !upSense) //Izqierda
        {
            mov = new Vector3(-velX, 0, 0);
        }
        else if (downSense && !rightSense && !leftSense && !upSense) //Abajo
        {
            mov = new Vector3(0, -velZ, 0);
        }
        else
        {
            Debug.Log("Datos no asignados o sobre asignacion de sentidos de movimiento");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CubePlayerMovement(Vector3 move)
    {
        Vector3 test = cubePlayer.transform.position;
        cubePlayer.AddForce(move);
    }

    public void RotateObject(Vector3 rot)
    {
        Vector3 test = cubePlayer.transform.position;
        cubePlayer.transform.Rotate(rot,Space.Self);
    }

    public void StopMovement()
    {
        cubePlayer.velocity = new Vector3(0,0,0);
    }
}
