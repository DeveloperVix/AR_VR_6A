using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TestScript : SecuenseController
{

    

    void Start()
    {
        ChangeRender();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.transform == this.gameObject.transform)
                {
                    Debug.Log("Boton " + this.gameObject.name);

                    sphere.SetActive(true);

                    GetComponent<SecuenseController>().CheckOrder(buttonNumberOrder);
                }
            }
        }
    }

    
}
