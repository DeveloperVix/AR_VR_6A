using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    Camera thisCamera;//variable tipo camara

    void Start()
    {
        thisCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//es clic izquierdo y 1 es para el derecho
        {
            Debug.Log("HICISTE CLIC IZQUIERDO");

            RaycastHit rayHit;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))//donde de clic será donde se creara el rayo
            {
                Debug.Log("SELEECIONASTE UN OBJETO :v");
                Seleccion seleccion = rayHit.collider.GetComponent<Seleccion>();//se guarda el objeto en donde choco el rayo(donde dimos clic) 
                if (!seleccion.isSelected)
                {
                    Debug.Log("Pausando animacion TOP");
                    seleccion.anim.speed = 0;
                    seleccion.isSelected = true;
                    //seleccion.Selected();
                }
                else
                {
                    seleccion.anim.speed = 1;
                    seleccion.isSelected = false;
                    //seleccion.Selected();
                }
            }
        }

    }

    
}
