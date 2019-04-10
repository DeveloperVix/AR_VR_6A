using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatChange : MonoBehaviour
{
    MeshRenderer meshrender;
    public Material PointMaterial;
    public Renderer obj;
    public Material UnPointedMaterial;


    // Start is called before the first frame update
    void Start()
    {
        meshrender = GetComponent<MeshRenderer>(); 
    }

    public void point()
    {
        obj.material = PointMaterial;
    }

    public void pointed()
    {
        obj.material = UnPointedMaterial;
    }
}
