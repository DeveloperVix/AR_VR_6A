using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //Clase principal que hereda de scriptableObject, se encuentran los elementos esenciales que toda interacción debe tener

public abstract class Interactivo : ScriptableObject
{
    public enum TypeInteraction{OnUpdate, Normal};          //Un enum para saber el tipo de interacción una vez que se crea el scriptable
    public TypeInteraction currentInteraction;                   //El valor actual de la interacción

    //Puesto que son diferentes interacciones y tendrán diferentes comportamientos, habra que sobreescribir el metodo
    //De antemano, en el analisis que se ha hecho, nos damos cuenta de que todas las interacciones necesitan de un objeto, razón
    //por la cual el metodo de ExecuteInteraction necesite de parametro un game object, el cual va a rotar, o va a reproducir un audio,
    //o simplemente activarse, etc.
    public abstract void ExecuteInteraction(GameObject obj);    //El metodo que se va a ejecutar cuando se este mirando
    public abstract void StopExecutionInteraction();            //El metodo que se va a ejecutar cuando no se este mirando
}
