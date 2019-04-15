using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPointer : MonoBehaviour
{
    public Material Normal;
    public Material PointEnter;
    public MeshRenderer meshRenderer;

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
