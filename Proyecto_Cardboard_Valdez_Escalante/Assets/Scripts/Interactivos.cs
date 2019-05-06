using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactivos : ScriptableObject
{
    public enum TypeInteraction { rotar, audio, imagen };
     public TypeInteraction currentInteraction;
    public abstract void StopExecutionInteraction();
    public abstract void ExecuteInteraction(GameObject obj);
}
