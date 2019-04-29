using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Instruccion esencial para crear el asset en nuestra carpeta de asstes
//  Definimos el apartado de Interactions / despues el tipo       Nombre del asset
[CreateAssetMenu(menuName = "MetPadreInter/rotar", fileName = "rotar")]

public class MetInterRotation : MetPadreInter    //Hereda de la clase Interactivo, la cual es scriptable object
{
     int speed = 10;
    GameObject Stop;

    public override void ExecuteInteraction(GameObject objToInteract)
    {
        Stop = objToInteract;
        objToInteract.transform.Rotate(1,1,1 * 2);
        Debug.Log("Estoy rotando we!");
    }
    public override void StopExecutionInteraction()
    {
        Stop.transform.Rotate(1*0,1*0,1*0);
        Debug.Log("Ya no me ve we, dejo de rotar");
    }
}