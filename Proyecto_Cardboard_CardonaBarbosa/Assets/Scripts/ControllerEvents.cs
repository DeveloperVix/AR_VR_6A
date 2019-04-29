using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEvents : MonoBehaviour
{
    public Material materialrojo;
    public Renderer cubo;
    public Material materialNormal;
    public Transform CuboRotate;
    public Transform CuboScale;
    public bool onStay = false;
    public bool onStayScale = false;



    
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
        if (onStayScale)
        {
            Vector3 scaleCube = CuboScale.transform.localScale;
            scaleCube.x += 0.002f;
            scaleCube.y += 0.002f;
            scaleCube.z += 0.002f;
            CuboScale.transform.localScale = scaleCube;
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
    public void ScaleCubo()
    {
        onStayScale = true;
    }
    public void ScaleCuboExit()
    {
        onStayScale = false;
    }
   
}
