using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class JuegoOrden : MonoBehaviour
{
    public float incremento = 0.2f;
    public float maxAlt = 0.8f;
    public float minAlt = 0.2f;
    public float tamañoCorrecto;

    GameObject camaraObj;
    protected Camera cam;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.layer == 13)
                {
                    GameObject fila = hit.collider.gameObject;
                    Vector3 trans = fila.transform.localScale;

                    trans.z += incremento;

                    if (trans.z >= (maxAlt+0.2f))
                    {
                        trans.z = maxAlt;
                    }

                    fila.transform.localScale = trans;
                }

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == 13)
                {
                    GameObject fila = hit.collider.gameObject;
                    Vector3 trans = fila.transform.localScale;

                    trans.z -= incremento;

                    if (trans.z <= (minAlt-0.2f))
                    {
                        trans.z = minAlt;
                    }

                    fila.transform.localScale = trans;
                }
            }
        }
    }

    


}
