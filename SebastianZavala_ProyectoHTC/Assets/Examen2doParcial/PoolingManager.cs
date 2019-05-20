using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    //Declarar un singleton para poder acceder a los metodos publicos en otros scripts    

    //Necesitamos el prefab para meterlo en la alberca
    public GameObject objeto1;
    //Definir el tamaño de la alberca
    int cucumber = 5;
    //Definir la cola (palabra reservada Queue) que sera nuestra alberca
    private Queue MegaPool;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializar la alberca cuando se hace la carga de juego InitPool();
    }

    //Definir metodo para inicializar la alberca
    public void InitPool()
    {
        
    }
    //Crear la cola
    //Con un ciclo vamos a crear los objetos en escena en base al tamaña de la alberca
    //Definir una variable del tipo GameObject e igualarle la instancia(Instantiate(prefab) NO NECESITA POSICION NI ROTACION) del objeto a crear
    //Meter dentro de la cola el objeto (nameCola.Enqueue(variableGameObject definida arriba)) palabra reservada "Enqueue" para encolar el nuevo objeto
    //Desactivar el objeto creado (variableGameObject definida arriba)



    //Definir metodo el cual se va a mandar llamar en la parte en donde dispara el jugador, el cual va a retornar un objeto
    //y recibe de parametros la posición y rotación
    public void Shooting()
    {

    }

    //Definir una variable del tipo GameObject e igualarle el ultimo objeto que esta en la cola (nameCola.Dequeue), usando la palabra reservada Dequeue
    //Teniendo en nuestra variable del tipo GameObject de arriba, activar el objeto
    //Asignarle la nueva posiciocion y rotacion que esta recibiendo como parametros el metodo 
    //Retornar el objeto, dado que nuestro metodo es del tipo GameObject


    //Este metodo mandarlo llamar cuando ya no necesitamos la bala, recibe de parametro el objeto que vamos a regresar a la alberca
    public void Swiming()
    {
        
    }

        //Desactivar el objeto que se esta recibiendo como parametro
        //Meter el objeto a la cola("Alberca") usando Enqueue("Encolar")
}
