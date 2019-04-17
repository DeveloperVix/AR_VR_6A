using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Instruccion esencial para crear el asset en nuestra carpeta de asstes
//  Definimos el apartado de Interactions / despues el tipo       Nombre del asset
[CreateAssetMenu(menuName ="Interactions/Rotate", fileName = "Rotate")]
public class Interactivo_Rotar : Interactivo    //Hereda de la clase Interactivo, la cual es scriptable object
{
    /*  IMPORTANTE
        
        Este interacivo tiene como objetivo hacer rotar un objeto, sin embargo, en los scriptable objects
        no podemos utilizar los metodos de Unity como el Update o el Start. Tampoco podemos hacer una variable publica
        y arrastrar el gameObject por que va a perder la referencia, tendriamos que buscarlo u obtenerlo cuando se reciba en el
        metodo "ExecuteInteraction".

        Entonces como el metodo sobreescrito que estamos heredando (ExecuteInteraction) recibe de parametro un GameObject, este metodo lo vamos a delegar
        en el script que va a estar ejecutando las diferentes interacciones
     */
    public int speed = 10;  //Velocidad para rotar
    
    public override void ExecuteInteraction(GameObject objToInteract)
    {
        //Ponemos las instrucciones especificas para que el objeto rote
        objToInteract.transform.Rotate(Vector3.up * Time.deltaTime * speed);
        Debug.Log("Estoy rotando we!");
    }

    public override void StopExecutionInteraction()
    {
        //Aqui pondriamos las instrucciones especificas para que el objeto deje rotar, puesto que este metodo es
        //abstracto, sedebe implementar, sin embargo, en el caso de ROTAR, no haria falta, aun así se puso el debug para corroborar
        //que se manda llamar el metodo cuando el jugaro no vea al objeto
        Debug.Log("Ya no me ve we, dejo de rotar");
    }
}
