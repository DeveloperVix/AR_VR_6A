using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material Normal;
    public Material PointEnter;
    //public Material MaterialAzul, MaterialAmarillo, MaterialRosa, MaterialVerde, MaterialRojo;//Crea dos variables del tipo Material 
    public MeshRenderer meshRenderer;
    //public int rand = Random.Range(0,4);

    public virtual void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();//obtener material 
    }

    public virtual void OnPointerEnter()
    {
        Debug.Log("CAMBIANDO DE COLOR");
        meshRenderer.material = PointEnter;
    }

    public virtual void OnPointerExit()
    {
        Debug.Log("CAMBIANDO DE COLOR");
        meshRenderer.material = Normal;
    }
}
