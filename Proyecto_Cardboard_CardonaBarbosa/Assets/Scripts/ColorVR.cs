using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Color", fileName = "Color")]
public class ColorVR : Scriptables
{
    public ColorVR()
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
