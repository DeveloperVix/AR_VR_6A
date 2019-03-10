using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Combinacion : MonoBehaviour
{
    Renderer rend;
    public Material material;

  

   

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("uno"))
        {
            Debug.Log("Encontrado");
            rend.sharedMaterial = material;



        }
    }
    
}
