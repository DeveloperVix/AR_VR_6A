using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaColor : MonoBehaviour, IInteractable
{
    MeshRenderer meshRender;

    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();    
    }
    public void LookOnMe()
    {
        Debug.Log("El player me ve");
        meshRender.material = materials[1];
    }

    public void NoLookOnMe()
    {
        Debug.Log("El player ya no me ve");
        meshRender.material = materials[0];
    }
}
