using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public Material Normal, Alternativo;
    Renderer Render;

    //bool Detected = false;

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

    public void Abrir()
    {
        transform.Translate(0, 4.4f, 0);
    }
}
