using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetodoInteractivo : MonoBehaviour, ObjInter 
{
    //ayudandonos del polimorfismo, vamos a tratar a todos del tipo "Interactivo"
    public MetPadreInter[] interactions;

    /*  Los scriptable objects no pueden ejecutar los metodos de Unity como el Update o el Start, etc.
        Vamos a utilizar un delegate para poder obtener el metodo que se encuentra en el scriptable object, esto solo lo vamos a hacer
        cuando la interaccion necesite ejecutar algo dentro del Update
     */
    //Creamos el delegado del tipo void, puesto que también el metodo del scriptable es del tipo void
    //le ponemos el nombre que queramos, y como el metodo del scriptable object
    //recibe un parametro del tipo GameObject, también tenemos que crearlo con esa condición
    delegate void ExecuteUpdate(GameObject obj);
    //Una vez que se ha creado el tipo de delegado, ya podemos crear una variable-metodo de dicho tipo (ExecuteUpdate)
    ExecuteUpdate currentExecution; //Nota: Solo estamos creando la variable-metodo

    public GameObject[] objInteraction; //Referencia de todos los objetos, como la imagen, el audio, etc

    public void LookOnMe()
    {

        for (int i = 0; i < interactions.Length; i++)
        {

            if (interactions[i].currentInteraction == MetPadreInter.TypeInteraction.rotar)
            {
                currentExecution = interactions[i].ExecuteInteraction;
            }
            else
            {
                interactions[i].ExecuteInteraction(objInteraction[i]);
            }
        }
    }

    public void NoLookOnMe()
    {
        for (int i = 0; i < interactions.Length; i++)
        {
            interactions[i].StopExecutionInteraction();    //Se manda llamar el metodo para detener la ejecución de cada scriptable
        }
        currentExecution = null;    //Y el delegado lo volvemos nulo para que ya no se ejecute en el Update
    }

    private void Update()
    {
        //  Para ejecutar el delegado, preguntamos sino es nulo
        if (currentExecution != null)
        {
            //Aqui se se esta mandando llamar el delegado como metodo, tenemos que mandarle el parametro del tipo GameObject, del arreglo de objetos
            //necesitamos saber cual
            currentExecution(objInteraction[0]);
        }
    }
}