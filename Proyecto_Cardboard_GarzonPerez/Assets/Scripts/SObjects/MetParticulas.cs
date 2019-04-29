using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MetPadreInter/particulas", fileName = "particulas")]

public class MetParticulas : MetPadreInter    //Hereda de la clase Interactivo, la cual es scriptable object
{
    GameObject Particula;

    public override void ExecuteInteraction(GameObject objToInteract)
    {
        Particula = objToInteract;
        Particula.GetComponent<ParticleSystem>().Play();
    }
    public override void StopExecutionInteraction()
    {
        Particula = null;
    }
}
