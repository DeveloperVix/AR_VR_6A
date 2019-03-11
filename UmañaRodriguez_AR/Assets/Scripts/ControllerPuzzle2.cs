using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPuzzle2 : MonoBehaviour
{
    [SerializeField]
    private Transform[] imagenes;

    [SerializeField]
    private Text winText;

    

    void Start()
    {
        winText.gameObject.SetActive(false);
        

    }

    void Update()
    {
        if (imagenes[0].rotation.z == 0 &&
            imagenes[1].rotation.z == 0 &&
            imagenes[2].rotation.z == 0 &&
            imagenes[3].rotation.z == 0)
        {
            
            winText.gameObject.SetActive(true);
            Debug.Log("Ganaste");
        }
    }
}
