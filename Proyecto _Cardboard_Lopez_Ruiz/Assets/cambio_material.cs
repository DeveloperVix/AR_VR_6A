using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambio_material : MonoBehaviour
{
    
    public Material cubo_material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
