using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Color", fileName = "Color")]
public class InteractColor : Interactive
{
    public InteractColor()
    {
        type = Type.Color;
    }

    public Material materialSeen, materialUnSeen;

    public override void OnNotSeen(GameObject obj)
    {
        obj.GetComponent<Renderer>().material = materialUnSeen;
    }

    public override void OnSeen(GameObject obj)
    {
        obj.GetComponent<Renderer>().material = materialSeen;
    }
}
