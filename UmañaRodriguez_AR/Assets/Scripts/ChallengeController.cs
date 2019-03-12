using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallengeController : MonoBehaviour
{
    public static bool primerDesafio = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (primerDesafio == true)
        {
            Debug.Log("Hola");
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("Cubo");
    }
}
