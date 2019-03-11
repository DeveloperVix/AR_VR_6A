using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform[] Points;
    public GameObject figura;
    public int currentPoint;
    public int speed;
    int ram;
    bool init = true;
    public int contGanar;
    // Start is called before the first frame update
    void Start()
    {
        ram = Random.Range(0,3);
       
    }

    // Update is called once per frame
    public void MoverFig()
    {
        for (int i = 0; i < Points.Length; i++)
        {
            if (figura.transform.position == Points[currentPoint].position)
            {
                currentPoint = (currentPoint + 1) % Points.Length;
            }
        }
    }
    private void Update()
    {
        if (init)
        {
            inicio();
        }
        figura.transform.position = Vector3.MoveTowards(figura.transform.position, Points[currentPoint].position, speed * Time.deltaTime);
        if (currentPoint == 0)
        {
            AR.contGanar1 += 1;
        }
        else if (currentPoint != 0)
        {
            AR.contGanar1 -= 1;
        }
    }

    void inicio()
    {
        for (int i = 0; i < Points.Length; i++)
        {
            if (figura.transform.position == Points[currentPoint].position)
            {
                currentPoint = (currentPoint + 1) % Points.Length;
                ram -= 1;
            }
        }
        if (ram < 0)
        {
            init = false;
        }
    }

}
