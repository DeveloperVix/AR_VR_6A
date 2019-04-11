using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColor : Interactivo
{
    public Material matNormal, matSelect;
    public Renderer render;


    public override void Ejecutar()
    {
        render = GetComponent<Renderer>();
        throw new System.NotImplementedException();
    }
}
