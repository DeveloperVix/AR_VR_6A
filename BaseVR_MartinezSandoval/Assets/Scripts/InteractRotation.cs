using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Rotation", fileName = "Rotation")]
public class InteractRotation : Interactive
{
    public InteractRotation()
    {
        type = Type.Rotation;
    }

    public enum RotateWhen { NotSeen, Seen }
    public RotateWhen rotateWhen;

    public float speed = 20;

    public override void OnSeen(GameObject obj)
    {
        if (rotateWhen == RotateWhen.Seen) obj.transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    public override void OnNotSeen(GameObject obj)
    {
        if (rotateWhen == RotateWhen.NotSeen) obj.transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
