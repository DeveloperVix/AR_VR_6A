using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estados/Audio", fileName = "Audio")]

public class Audio : Interactivo
{
    AudioSource aud;
    // Start is called before the first frame update
    public override void Esperando(GameObject obj)
    {
        
        aud = obj.GetComponent<AudioSource>();
        aud.Pause();
    }

    public override void Ejecutar(GameObject obj)
    {
        aud = obj.GetComponent<AudioSource>();
        aud.Play();
        Debug.Log("Reproduciendo Audio");
    }
}
