using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/Particulas", fileName = "Particulas")]

public class Particulas : Interactive
{
    ParticleSystem particula;

    public override void DejaDeEjecutar(GameObject obj)
    {
        particula = obj.GetComponent<ParticleSystem>();
        particula.Stop();
    }

    public override void Ejecutar(GameObject obj)
    {
        particula = obj.GetComponent<ParticleSystem>();
        Debug.Log("Entro");
        particula.Play();
        Debug.Log("Particulas");
    }
}
