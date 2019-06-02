using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Type of action/ChangeColor", fileName = "ChangeColor")]

public class ChangeColor : Interactive
{

    public MeshRenderer meshRen;
    public Material mat;
    public Material mat2;

    // Start is called before the first frame update
    void Awake()
    {
        meshRen = GetComponent<MeshRenderer>();
    }

    private T GetComponent<T>()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ExecuteAction()
    {
        throw new System.NotImplementedException();
    }

    public override void Targeted()
    {
        meshRen.material = mat2;
    }

    public override void Untargeted()
    {
        meshRen.material = mat;
    }
}
