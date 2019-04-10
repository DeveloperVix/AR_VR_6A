using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat : MonoBehaviour
{
    public Material Normal, Cambio;
    Renderer Ren;
    // Start is called before the first frame update
    void Start()
    {
        Ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambioColor(bool Col)
    {
        Ren.material = Col ? Cambio : Normal;
    }
}
