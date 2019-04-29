using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractivoTexto : MenuInteractivo
{
    public override void DetenerAccion()
    {
        GameObject objText = GameObject.Find("textoInteractivo");
        Text text = objText.GetComponent<Text>();
        text.enabled = false;
    }

    public override void Ejecutar(GameObject obj)
    {
        GameObject objText = GameObject.Find("textoInteractivo");
        Text text = objText.GetComponent<Text>();
        text.enabled = true;
    }
}
