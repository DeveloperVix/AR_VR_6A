using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Particle", fileName = "Particle")]
public class InteractParticles : Interactive
{
    public InteractParticles()
    {
        type = Type.Particle;
    }

    public GameObject prefabParticles;
    private ParticleSystem particles;

    public override void OnNotSeen(GameObject obj)
    {
        CheckParticleSystem(obj);
        if (particles.isPlaying) particles.Stop();
    }

    public override void OnSeen(GameObject obj)
    {
        CheckParticleSystem(obj);
        if (!particles.isPlaying) particles.Play();
    }

    void CheckParticleSystem(GameObject obj)
    {
        if(particles == null) particles = Instantiate(prefabParticles, obj.transform).GetComponent<ParticleSystem>();
    }
}
