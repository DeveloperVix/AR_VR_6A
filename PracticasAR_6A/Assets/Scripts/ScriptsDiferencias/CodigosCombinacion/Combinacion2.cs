using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinacion2 : MonoBehaviour
{
    Renderer rend;
    public Material material;
    public Material materialError;

    public bool isCorrect;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("dos"))
        {
            Debug.Log("Encontrado");
            rend.sharedMaterial = material;
            isCorrect = true;


        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("dos"))
        {
            Debug.Log("Encontrado");
            rend.sharedMaterial = materialError;

            isCorrect = false;

        }
    }
}
