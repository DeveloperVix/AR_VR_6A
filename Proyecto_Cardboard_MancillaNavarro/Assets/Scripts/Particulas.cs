using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/Particulas", fileName = "Particulas")]

public class Particulas : Interactivo
{
    ParticleSystem particula;
    public override void Esperando(GameObject obj)
    {
        particula = obj.GetComponent<ParticleSystem>();
        particula.Stop();
    }

    public override void Ejecutar(GameObject obj)
    {
        particula.Play();
        Debug.Log("Particulas");
    }
}
