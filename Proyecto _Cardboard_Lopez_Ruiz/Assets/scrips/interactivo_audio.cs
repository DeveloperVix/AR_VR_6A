using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "interactions/audio", fileName = "audio")]
public class interactivo_audio : interactivo
{
    GameObject objaudio;

    public override void ejecutarinteraccion(GameObject audi)
    {
        objaudio = audi;
        objaudio.GetComponent<AudioSource>().Play();
    }
    public override void detenerejecucion()
    {
        objaudio = null;
    }
}
