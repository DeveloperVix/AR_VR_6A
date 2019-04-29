using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivoAudio : MenuInteractivo
{
    AudioSource sonido;

    public override void DetenerAccion()
    {
        sonido.Stop();
    }

    public override void Ejecutar(GameObject obj)
    {
        sonido.Play();
    }
}
