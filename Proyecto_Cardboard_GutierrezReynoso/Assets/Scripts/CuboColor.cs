using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboColor : MonoBehaviour
{
    
    MeshRenderer meshRen;
    public bool flag;

    // Start is called before the first frame update
    void Start()
    {
        meshRen = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            transform.Rotate(new Vector3(1, 0, 5));
        }
    }

    public void changeMaterial(Material mat)
    {
        meshRen.material = mat;
    }

    public void rotateCube(bool bandera)
    {
        flag = bandera;
    }
}
