using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "interactions/particulas", fileName = "particulas")]
public class interaccion_particulas : interactivo
{
    GameObject objparticulas;

    public override void ejecutarinteraccion(GameObject objpartic)
    {
        objparticulas = objpartic;
        objpartic.SetActive(true);
    }
    public override void detenerejecucion()
    {
        objparticulas.SetActive(false);
        objparticulas = null;
    }
}
