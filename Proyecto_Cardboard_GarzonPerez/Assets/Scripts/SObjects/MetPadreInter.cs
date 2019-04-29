using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase principal que hereda de scriptableObject, se encuentran los elementos esenciales que toda interacción debe tener

public abstract class MetPadreInter : ScriptableObject
{
    public enum TypeInteraction { rotar, audio, imagen, color, particulas };         
    public TypeInteraction currentInteraction;                   

    //Puesto que son diferentes interacciones y tendrán diferentes comportamientos, habra que sobreescribir el metodo
    //De antemano, en el analisis que se ha hecho, nos damos cuenta de que todas las interacciones necesitan de un objeto, razón
    //por la cual el metodo de ExecuteInteraction necesite de parametro un game object, el cual va a rotar, o va a reproducir un audio,
    //o simplemente activarse, etc.
    public abstract void ExecuteInteraction(GameObject obj);    
    public abstract void StopExecutionInteraction();            
}