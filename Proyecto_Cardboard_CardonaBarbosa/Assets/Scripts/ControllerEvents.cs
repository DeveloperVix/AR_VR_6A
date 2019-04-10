using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEvents : MonoBehaviour
{
    public Material materialrojo;
    public Renderer cubo;
    public Material materialNormal;
    // Start is called before the first frame update
    void Start()
    {
        cubo = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onChangeMaterial()
    {
        cubo.material = materialrojo;
        
    }
    public void onExiteMaterial()
    {
        cubo.material = materialNormal;
    }
}
