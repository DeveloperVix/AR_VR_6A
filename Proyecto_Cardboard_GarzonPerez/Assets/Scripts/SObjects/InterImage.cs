using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MetPadreInter/imagen", fileName = "imagen")]
public class InterImage : MetPadreInter 
{
    GameObject tempObj;

    public override void ExecuteInteraction(GameObject obj)
    {
        Debug.Log("Muestro la imagen");
        tempObj = obj;
        obj.SetActive(true);
    }

    public override void StopExecutionInteraction()
    {
        Debug.Log("Desactivo la imagen");
        tempObj.SetActive(false);
        tempObj = null;
    }

}