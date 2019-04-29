using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/Audio", fileName = "Audio")]

[RequireComponent(typeof(AudioSource))]
public class Audio : Interactive
{
    
    AudioSource audio;
    public override void DejaDeEjecutar(GameObject obj)
    {
        //audio = obj.GetComponent<AudioSource>();
        audio.Pause();
        
    }

    public override void Ejecutar(GameObject obj)
    {
        audio = obj.GetComponent<AudioSource>();
        audio.Play();
        Debug.Log("Reproduciendo Audio");
    }
}
