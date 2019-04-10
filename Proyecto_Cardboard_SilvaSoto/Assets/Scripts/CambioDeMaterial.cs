using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeMaterial : MonoBehaviour
{
    public Material Normal, Alternativo;
    Renderer Render;

    // Start is called before the first frame update
    void Start()
    {
        Render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(bool xd)
    {
        Render.material = xd ? Alternativo : Normal;
    }
}
