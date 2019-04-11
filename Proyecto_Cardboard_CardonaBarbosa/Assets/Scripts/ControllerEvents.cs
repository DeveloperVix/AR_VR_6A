using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEvents : MonoBehaviour
{
    public Material materialrojo;
    public Renderer cubo;
    public Material materialNormal;
    public Transform CuboRotate;
    public bool onStay = false;



    
    // Start is called before the first frame update
    void Start()
    {
        cubo = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onStay)
        {
            CuboRotate.Rotate(100* Time.deltaTime, 0, 0);
        }  
    }
    public void onChangeMaterial()
    {
        cubo.material = materialrojo;
        
    }
    public void onExiteMaterial()
    {
        cubo.material = materialNormal;
    }
    public void RotateCubo()
    {
        onStay = true;
        Debug.Log("Entro");
    }
    public void RotateCuboExit()
    {
        onStay = false;
        Debug.Log("Salii");
    }
   
}
