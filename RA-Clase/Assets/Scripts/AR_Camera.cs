using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Camera : MonoBehaviour
{

    public LayerMask objSeleccionado;

    Camera thisCamera;

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
                seleccionFigura selFigura = rayhit.collider.GetComponent<seleccionFigura>();
                Debug.Log("figura seleccionada");
                
                if(!selFigura.estaSeleccionada)
                {
                    selFigura.estaSeleccionada = true;
                    selFigura.Seleccionado();
                }        
            }

            else
            {
                seleccionFigura selFig = rayhit.collider.GetComponent<seleccionFigura>();
                selFig.estaSeleccionada = false;
                selFig.Seleccionado();
            }
        }
    }
}
