using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarNormal : MonoBehaviour
{

    public Material C1, C2;
    public MeshRenderer OBJ;
    void Start()
    {
        OBJ = GetComponent<MeshRenderer>();
    }

    public void PointEnter()
    {
        OBJ.material = C2;
    }
    public void PointExit()
    {
        OBJ.material = C1;
    }
}
