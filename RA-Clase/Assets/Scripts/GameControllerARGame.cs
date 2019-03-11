using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerARGame : MonoBehaviour
{
    public int PuzlesCompletados;
    public GameObject felicitaciones;

    // Start is called before the first frame update
    void Start()
    {
        PuzlesCompletados = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Animator complete = felicitaciones.GetComponent<Animator>();
        bool IsComplete = complete.GetBool("Completado");

        if(PuzlesCompletados == 6)
        {
            complete.SetBool("Completado", IsComplete = true);
        }
    }
}
