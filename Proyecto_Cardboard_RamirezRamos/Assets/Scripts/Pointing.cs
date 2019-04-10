using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointing : MonoBehaviour
{
    //MeshRenderer MeshRndr;
    //public Material[] materials;
    public Material PointedMaterial;
    public Material UnpointedMaterial;
    public Renderer obj;

   
    void Start()
    {
        //MeshRndr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Point()
    {
        obj.material = PointedMaterial;
    }

    public void Unpointed()
    {
        obj.material = UnpointedMaterial;
    }
}
