using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambiar : MonoBehaviour
{

    public Material C1, C2;
    public MeshRenderer OBJ;
    void Start()
    {
        OBJ = GetComponent<MeshRenderer>();
    }

    public void pointEnter()
    {
        OBJ.material = C2;
    }
    public void pointExit()
    {
        OBJ.material = C1;
    }
}
