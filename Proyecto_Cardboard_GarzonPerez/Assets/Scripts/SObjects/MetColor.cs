using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MetPadreInter/color", fileName = "color")]

public class MetColor : MetPadreInter    //Hereda de la clase Interactivo, la cual es scriptable object
{
    Renderer Ren;
    public Material Cambio, Normal;


    public override void ExecuteInteraction(GameObject objToInteract)
    {
        Ren = objToInteract.GetComponent<MeshRenderer>();
        objToInteract.GetComponent<MeshRenderer>().material = Cambio;
    }
    public override void StopExecutionInteraction()
    {
        Ren.material = Normal;
    }
}