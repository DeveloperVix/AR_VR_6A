using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Change_Script : MonoBehaviour
{

    public Material MaterialA, MaterialB;
    private MeshRenderer MeshRender;
        
    // Start is called before the first frame update
    void Start()
    {
        MeshRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMaterial()
    {
       MeshRender.material = MaterialA;
    }

    public void DefaultMaterial()
    {
        MeshRender.material = MaterialB;
    }
}
