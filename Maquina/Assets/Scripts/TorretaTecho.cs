using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaTecho : MonoBehaviour
{
    public enum StatusTorre { PATRULLAJE, ALERTA, APUNTAR, DISPARAR };
    public StatusTorre currentStatus;

    [Header("Estado patrullaje")]
    public float waitTime = 1f;         //Tiempo de espera cuando se llega al limite del angulo de rotacion
    public Quaternion rightAngle;
    public Quaternion leftAngle;
    public int speed = 10;


    void Start()
    {
        
    }
    0
    void Update()
    {
        
    }

    void estadoPatrullaje() {
        if (transform.rotation.z < rightAngle.z && transform.rotation.z < leftAngle.z) {
            transform.rotation = Quaternion.Lerp(transform.rotation, rightAngle, Time.time * speed);
        }
    }
}
