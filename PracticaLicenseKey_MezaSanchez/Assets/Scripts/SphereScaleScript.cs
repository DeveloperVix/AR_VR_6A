using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScaleScript : ScaleScript
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                    ScaleObj();
                }

            }
        }
    }
}
