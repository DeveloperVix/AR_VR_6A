using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Interactions/Text", fileName = "Text")]
public class Interactivo_Texto : Interactivo
{
    public GameObject text;
    public GameObject cord;
    public override void ExecuteInteraction(GameObject obj)
    {
        cord = GameObject.Find("Canvas/Coordenadas");
        Instantiate(text,cord.transform.position,Quaternion.identity,GameObject.Find("Canvas").transform);
    }   
    public override void StopExecutionInteraction()
    {
        GameObject.Find("Canvas/Text(Clone)").SetActive(false);
    }
}
