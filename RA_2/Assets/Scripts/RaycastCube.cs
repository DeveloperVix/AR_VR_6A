using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCube : MonoBehaviour
{
    Camera thisCamera;
    Camera MainCam;
    Vector3 mouseInitialPosition;
    Vector3 mouseFinalPosition;
    public GameObject[] Waypoints;
    Rigidbody rb;

    int vel = 3;

    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToWaypoint();

        /*if (Input.GetMouseButtonDown(0))
        {
            //mouseInitialPosition = Camera.current.ScreenToViewportPoint(Input.mousePosition);
            //mouseInitialPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);
            RaycastHit rayHit;
            //if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
            if (Physics.Raycast(Camera.current.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
            {
                MoveToWaypoint();
            }

        }*/
    }

    public void MoveToWaypoint()
    {
        
        for (int i = 0; i < Waypoints.Length; i++)
        {
            if (rb.transform.position != Waypoints[i].transform.position)
            {
                rb.transform.position = Waypoints[i].transform.position;
            }
        }
    }
}
