using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  Este script es que se debera poner a todo objeto que queramos que tenga interacciones, la cantidad de interacciones
    se guardaran en un arreglo y que se ejecutaran con un metodo que se debe implementar con una interfaz
 */
public class ObjInteractivo : MonoBehaviour, IInteractable //implementamos la interfaz IInteractable
{
    //El arreglo donde pondremos todos los scriptable objects de interacción,
    //ayudandonos del polimorfismo, vamos a tratar a todos del tipo "Interactivo"
    public Interactivo[] interactions;

    /*  Los scriptable objects no pueden ejecutar los metodos de Unity como el Update o el Start, etc.
        Vamos a utilizar un delegate para poder obtener el metodo que se encuentra en el scriptable object, esto solo lo vamos a hacer
        cuando la interaccion necesite ejecutar algo dentro del Update
     */
    //Creamos el delegado del tipo void, puesto que también el metodo del scriptable es del tipo void
    //le ponemos el nombre que queramos, y como el metodo del scriptable object
    //recibe un parametro del tipo GameObject, también tenemos que crearlo con esa condición
    delegate void ExecuteUpdate (GameObject obj);
    //Una vez que se ha creado el tipo de delegado, ya podemos crear una variable-metodo de dicho tipo (ExecuteUpdate)
    ExecuteUpdate currentExecution; //Nota: Solo estamos creando la variable-metodo

    public GameObject[] objInteraction; //Referencia de todos los objetos, como la imagen, el audio, etc

    //Metodo a implementar dada la interfaz IInteractable
    public void LookOnMe () {
        /*  Este metodo se va a mandar llamar en el EventTrigger del objeto, este metodo solo se manda llamar UNA VEZ
            
            Como no sabremos cuantas interacciones va a tener en el arreglo de "interactions", puede ser 1 o 5 o las que sean
            recorremos el arreglo con un ciclo for y mandamos llamar el metodo de "ExecuteInteraction"
         */
        for (int i = 0; i < interactions.Length; i++) {
            /*  Cuando hacemos el recorrido, es importante saber que tipo de interaccion estamos revisando, puesto que hay interacciones
                que van a requerir ejecutar su metodo en el Update, entonces accedemos al enum de cada interaccion y preguntamos que tipo de
                interacción es, por ejemplo rotar, si es el caso asignamos la delegación a nuestra variable-metodo del tipo "ExecuteUpdate"
             */

            if (interactions[i].currentInteraction == Interactivo.TypeInteraction.rotar) {
                //Nota: En el enum en vez de tener los diferentes tipos de interacción, podriamos poner algo como: ExecuteOnUpdate, NoUpdate,
                //para de esta forma solo tener dos tipos en el enum y asignar las delegaciones

                //asignamos la delegación a nuestra variable-metodo del tipo "ExecuteUpdate", notar que, todavía no le pasamos el parametro del 
                //tipo GameObject, puesto que solo estamos asignando la delegación
                currentExecution = interactions[i].ExecuteInteraction;
            } else {
                //Si el tipo de interactivo no se va a ejecutar en el Update, solo lo mandamos llamar, hay que saber que objetos se van a requerir en el 
                //update y cuales no
                interactions[i].ExecuteInteraction (objInteraction[1]); 
            }
        }
    }

    public void NoLookOnMe () {
        /*  Este metodo solo se manda llamar UNA VEZ

            Cuando ya el jugador no esta observando al objeto, vamos a mandar llamar el metodo para detener la ejecución
            de cada scriptable object que tenga el objeto, con un ciclo for
         */
        for (int i = 0; i < interactions.Length; i++) {
            interactions[i].StopExecutionInteraction ();    //Se manda llamar el metodo para detener la ejecución de cada scriptable
        }
        currentExecution = null;    //Y el delegado lo volvemos nulo para que ya no se ejecute en el Update
    }

    private void Update () {
        //  Para ejecutar el delegado, preguntamos sino es nulo
        if (currentExecution != null)
        {
            //Aqui se se esta mandando llamar el delegado como metodo, tenemos que mandarle el parametro del tipo GameObject, del arreglo de objetos
            //necesitamos saber cual
            currentExecution (objInteraction[0]); 
        }
    }

    /*Nota: Se puede tener una variable del tipo GameObject para mandarsela de parametro a nuestro delegado, por que cuando sea una imagen, un audio
            particulas, etc. Vamos a necesitar ese objeto en especifico para ejecutarlo.
            En caso de que se necesiten ejecutar más metodos en el Update, cabe mencionar que solo se puede delegar una vez, entonces habría que
            crear más delegados o crear un arreglo de delegados y mandarlos llamar en el update, aunque, hay que tener cuidado con los ciclos en el Update
    */

}