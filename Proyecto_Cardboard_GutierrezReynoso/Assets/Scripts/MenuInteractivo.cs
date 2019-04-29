using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuInteractivo : ScriptableObject
{
    public enum TypeInteraction { color, rotar, texto, particula, audio}
    public TypeInteraction currentInteraction;

    public abstract void Ejecutar(GameObject obj);
    public abstract void DetenerAccion();
}
