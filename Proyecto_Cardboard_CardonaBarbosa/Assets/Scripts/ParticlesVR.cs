using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Particles", fileName = "Particles")]
public class ParticlesVR : Scriptables
{
    public ParticlesVR()
    {
        type = Type.Particles;
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
        if (particles == null) particles = Instantiate(prefabParticles, obj.transform).GetComponent<ParticleSystem>();
    }
}
