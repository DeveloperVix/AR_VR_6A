using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat : MonoBehaviour
{
    public Material Normal, Cambio;
    Renderer Ren;
    void Start()
    {
        Ren = GetComponent<Renderer>();
    }
    void Update()
    {
    }
    public virtual void cambioColor(bool Col)
    {
        Ren.material = Col ? Cambio : Normal;
    }
}
