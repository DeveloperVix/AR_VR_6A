using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectFigure : MonoBehaviour
{
    [Header("Puntos obtenibles de la prueba")]
    public int Points = 0;
    public int puntosObtenibles = 1;
    [Header("Figuras de")]
    public GameObject Figura;
    public GameObject FiguraPrincipal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (Figura.tag == FiguraPrincipal.tag)
            {

                if (puntosObtenibles == 1)
                {
                    Debug.Log("Figura correcta!");
                    puntosObtenibles -= 1;
                    Debug.Log("Obtuviste un punto de la prueba");
                    Points += 1;
                }

                if (puntosObtenibles <= 0)
                {
                    puntosObtenibles = 0;
                }
                if (Points >= 1)
                {
                    Points = 1;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
