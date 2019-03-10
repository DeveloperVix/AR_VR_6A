using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : ControlsController
{
    // Start is called before the first frame update
    void Start()
    {
        if (upSense && !rightSense && !leftSense && !downSense) //Arriba
        {
            mov = new Vector3(velX, 0, 0);
        }
        else if (rightSense && !leftSense && !downSense && !upSense) //Derecha
        {
            mov = new Vector3(0, 0, -velZ);
        }
        else if (leftSense && !rightSense && !downSense && !upSense) //Izqierda
        {
            mov = new Vector3(0, 0, velZ);
        }
        else if (downSense && !rightSense && !leftSense && !upSense) //Abajo
        {
            mov = new Vector3(-velX, 0, 0);
        }
        else
        {
            Debug.Log("Datos no asignados o sobre asignacion de sentidos de movimiento");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.transform == this.gameObject.transform)
                {
                    Debug.Log("Boton " + this.gameObject.name);
                    RotateObject(mov);
                }

            }
        }

    }
}
