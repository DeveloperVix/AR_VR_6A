using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : RaycastCube
{
    Camera thisCamera;
    Camera MainCam;
    Vector3 mouseInitialPosition;
    Vector3 mouseFinalPosition;
    //public GameObject[] Waypoints;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //mouseInitialPosition = Camera.current.ScreenToViewportPoint(Input.mousePosition);
            //mouseInitialPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);
            RaycastHit rayHit;
            //if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
            /*if (Physics.Raycast(Camera.current.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
            {
                MoveToWaypoint();
            }*/

        }
    }

}
