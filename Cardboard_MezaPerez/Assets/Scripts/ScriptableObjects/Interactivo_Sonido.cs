using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Interactions/Sonds", fileName = "Sonds")]
public class Interactivo_Sonido : Interactivo
{
    GameObject tempObj;
    
    public override void ExecuteInteraction(GameObject obj)
    {
        tempObj = obj;
        obj.GetComponent<AudioSource>().Play();
    }
    public override void StopExecutionInteraction()
    {

        tempObj.GetComponent<AudioSource>().Stop();
        tempObj = null;
    }
}
