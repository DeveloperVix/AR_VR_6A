using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    puntos punt;
    
    int[] secuencia;

    public int cont = 0;
    public int chances = 4;
    //int intentos = 4;
    private int PuzzlePoints = 1;
    
    public int Points = 0;
    [Header("Puntos obtenidos de esta prueba")]
    public int Puntaje = 0;
    public GameObject[] Figura;
    public GameObject FiguraPrincipal;

    // Start is called before the first frame update
    void Start()
    {
        puntos.Inst.Contador();
    }

    // Update is called once per frame
    void Update()
    {

        //Keyboard();

    }

    /*void Keyboard()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.LogError(" Boton rojo presionado!");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.LogError(" Boton verde presionado!");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.LogError(" Boton azul presionado!");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.LogError(" Boton amarillo presionado!");
        }
    }*/

    void OnMouseDown()
    {

        #region Figuras
        //figura 1
        if (Figura[0].tag == "rojo")
        {
            Debug.Log("Boton rojo presionado!");
            Points += 1;
            

        }
        //figura 2
        if (Figura[0].tag == "verde")
        {
            Debug.Log("Boton verde presionado!");
            Points += 2;

        }
        //figura 3
        if (Figura[0].tag == "azul")
        {
            Debug.Log("Boton azul presionado!");
            Points += 3;

        }
        //figura 4
        if (Figura[0].tag == "amarillo")
        {
            Debug.Log("Boton amarillo presionado!");
            Points += 4;

        }
        cont += 1;
        PayToWinXD();

        //
        #endregion
        //PayToWinXD();
    }

    void PayToWinXD()
    {

            //cont += 1;
            Debug.Log("cont: " + cont);

            if (cont >= 4)
            {
                if (Points == 10)
                {
                    Debug.Log("Pulsaste correctamente la secuencia, felicidades!");
                }
                else
                {
                    Debug.Log("Secuencia incorrecta, vuelve a intentarlo!");
                }
            }

            if (cont >= chances)
            {
                cont = chances;
            }
    }
     
}
