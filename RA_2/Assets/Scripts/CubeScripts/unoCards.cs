using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unoCards : MonoBehaviour
{
    [Header("Total de veces a clickear")]
    public int vida = 2;
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
        if (vida <= 0)
        {
            vida = 0;
        }
    }
}
