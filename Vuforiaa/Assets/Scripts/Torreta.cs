using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour {

    // Variables para gestionar el radio de visión y velocidad
    public float visionRadius;
    public float Speed;
    public int speed;
    // Variable para guardar al jugador
    GameObject player;
    // Variable para guardar la posición inicial
    Vector3 initialPosition;



    // Use this for initialization
    void Start () {
        // Recuperamos al jugador gracias al Tag
        player = GameObject.FindGameObjectWithTag("player");

    }

    // Update is called once per frame
    void Update () {

        // Por defecto nuestro objetivo siempre será nuestra posición inicial
        Vector3 target = initialPosition;

        // Pero si la distancia hasta el jugador es menor que el radio de visión el objetivo será él
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius) {

            transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
        else {

            transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
        }

        // Finalmente movemos al enemigo en dirección a su target
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        // Y podemos debugearlo con una línea
        Debug.DrawLine(transform.position, target, Color.green);

        
	}
     void OnDrawGizmos() {

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, visionRadius);

    }
}

