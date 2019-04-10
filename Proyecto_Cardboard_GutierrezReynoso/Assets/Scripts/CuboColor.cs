using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboColor : MonoBehaviour
{
    
    MeshRenderer meshRen;

    // Start is called before the first frame update
    void Start()
    {
        meshRen = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMaterial(Material mat)
    {
        meshRen.material = mat;
    }
}
