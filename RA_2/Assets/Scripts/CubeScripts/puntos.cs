using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntos : MonoBehaviour
{
    private static puntos inst;
    public static puntos Inst { get { return inst; } }
    int cont = 0;
    int intentos = 4;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Contador()
    {
        cont = 1;
    }
}
