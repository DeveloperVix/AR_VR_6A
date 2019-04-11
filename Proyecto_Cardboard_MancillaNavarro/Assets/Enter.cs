using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public Renderer cubo;
    public Material newMAterial;
    public Material normalMAterial;
    // Start is called before the first frame update
    void Start()
    {
        cubo = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEnter()
    {
        cubo.material = newMAterial;
       
    }
    public void OnExitMAterial()
    {
        cubo.material = normalMAterial;

    }
}
