using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material mat;
    MeshRenderer mesh;



    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {

    }

    public void MatChange(Material mat)
    {
        mesh.material = mat;
    }


}
