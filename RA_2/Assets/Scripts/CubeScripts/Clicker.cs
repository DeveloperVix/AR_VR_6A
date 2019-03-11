using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [Header("Total de veces a clickear")]
    public int vida = 3;
    public int objetivos = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        vida -= 1;
        Debug.Log("clicks restantes: " + vida);
        if (vida == 0)
        {
            Debug.Log("Objetivo eliminado");
            Destroy(gameObject);
            objetivos -= 1;
        }
    }

    private void Checar()
    {
        
        
    }
}
