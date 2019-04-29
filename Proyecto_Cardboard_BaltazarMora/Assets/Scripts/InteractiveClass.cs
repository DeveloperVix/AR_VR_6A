using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveClass : ScriptableObject
{
    public int Type;

    void start()
    {

    }

    void Update()
    {

    }
    
    void CubeAccion()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Type == 1)
            {
                //cambia color
            }

            if (Type == 2)
            {
                //rotar
            }

            if (Type == 3)
            {
                //reproducir audio
            }

            if (Type == 4)
            {
                //mostrar texto
            }

            if (Type == 5)
            {
                //reproducir particulas
            }
        }
    }

}
