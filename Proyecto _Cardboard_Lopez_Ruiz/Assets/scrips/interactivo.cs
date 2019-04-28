using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactivo : ScriptableObject
{
    public enum tipodeinteraccion {rotar,audio,imagen,color,particulas}
    public tipodeinteraccion interaccionactual;

    public abstract void ejecutarinteraccion(GameObject obj);
    public abstract void detenerejecucion();

}
