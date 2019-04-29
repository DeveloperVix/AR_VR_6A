using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactivo : ScriptableObject
{
    public enum TipoInteractivo { Rotar, ReproduceAudio, CambiarColor, Particulas, EnsenarTexto };

    public TipoInteractivo interaccion;

    public abstract void Ejecutar(GameObject obj);

    public abstract void Esperando(GameObject obj);
}
