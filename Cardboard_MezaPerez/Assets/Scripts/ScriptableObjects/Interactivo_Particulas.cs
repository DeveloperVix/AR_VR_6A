using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interactions/Particles", fileName = "Particles")]
public class Interactivo_Particulas : Interactivo
{
    public GameObject particles;
    public override void ExecuteInteraction(GameObject obj)
    {
        Instantiate(particles, obj.transform.position, Quaternion.identity);
    }
    public override void StopExecutionInteraction()
    {
        Destroy(GameObject.Find("Particle(Clone)"),0.3f);
    }
}
