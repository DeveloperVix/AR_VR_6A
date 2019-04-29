using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : ScriptableObject
{

    public enum TipoInteractivo { RotarObjeto, ReproduceAudio, CambiarColor, Particulas, MostrarTexto };

    public TipoInteractivo interaccion;

    public abstract void Ejecutar(GameObject obj);

    public abstract void DejaDeEjecutar(GameObject obj);
}
