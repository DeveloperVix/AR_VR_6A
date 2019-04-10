using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material normal;
    public Material selected;
    MeshRenderer r;


    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Detectado()
    {
        r.material = selected;
    }

    public void NoDetectado()
    {
        r.material = normal;
    }
}
