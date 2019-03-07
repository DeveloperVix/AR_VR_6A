using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Camera : MonoBehaviour
{

    public LayerMask objSeleccionado;

    Camera thisCamera;

    public GameObject seleccionado;

    Vector3 mousePosition;

    // Start is called before the first frame update
    void Awake()
    {
        thisCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);
            RaycastHit rayhit;
            if(Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayhit, Mathf.Infinity, objSeleccionado))
            {
                seleccionado = rayhit.collider.gameObject;
            }
        }
    }
}
