using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambio_material : MonoBehaviour
{
    
    public Material cubo_material;
    public GameObject cubo2;
    bool rota = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rota = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rota == true)
        {
            cubo2.transform.Rotate(1, 1, 1 * 2);
        }
        if(rota == false)
        {
            cubo2.transform.Rotate(1*0, 1*0, 1 * 0);
        }
    }
    public void sobre()
    {
        GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("lol sobres");
    }
    public void fuera()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log("lol fuera");
    }
    public void rotacion_cubo()
    {
        rota = true;
    }
    public void detener_cubo()
    {
        rota = false;
    }
}
