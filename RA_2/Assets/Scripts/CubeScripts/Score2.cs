using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score2 : Score
{

    GameObject score;

    private int PuzzlePoints = 1;
    [Header("Puntos obtenidos de esta prueba")]
    public int Points = 0;
    
    public int Totalclicks = 30;
    public int currentClicks = 0;
    // Start is called before the first frame update
    void Start()
    {
        //score.GetComponent<Score>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Score();
        if (Points < 1)
        {
            GivePoint();
        }
    }

    public void Score()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.LogError(" Boton presionado!");
            currentClicks += 1;

            if (currentClicks >= Totalclicks)
            {
                Debug.LogError(" Has alcanzado el objetivo!");
                currentClicks = Totalclicks;
            }
        }        
    }

    public void OnMouseDown()
    {
        Debug.LogError(" Boton presionado!");
        currentClicks += 1;
        if (currentClicks >= Totalclicks)
        {
            Debug.LogError(" Has alcanzado el objetivo!");
            currentClicks = Totalclicks;
        }
    }
    public void GivePoint()
    {
        if (currentClicks == Totalclicks)
        {
            Points += 1;
            Debug.LogError("Has Obtenido 1 punto por completar el desafío!");
        }
    }
}
