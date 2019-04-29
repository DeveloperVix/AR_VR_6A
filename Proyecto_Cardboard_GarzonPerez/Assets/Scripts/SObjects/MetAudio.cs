using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MetPadreInter/audio", fileName = "audio")]

public class MetAudio : MetPadreInter    //Hereda de la clase Interactivo, la cual es scriptable object
{
    GameObject AudioEscena;
    public override void ExecuteInteraction(GameObject objToInteract)
    {
        AudioEscena = objToInteract;
        AudioEscena.GetComponent<AudioSource>().Play();
    }
    public override void StopExecutionInteraction()
    {
        AudioEscena.GetComponent<AudioSource>().Stop();
    }
}
