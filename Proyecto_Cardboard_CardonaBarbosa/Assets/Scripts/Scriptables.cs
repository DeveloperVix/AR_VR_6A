using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scriptables : ScriptableObject
{
    public enum Type { Color, Rotation, Text, Particles, Audio }
    public Type type;

    public abstract void OnSeen(GameObject obj);
    public abstract void OnNotSeen(GameObject obj);
}
