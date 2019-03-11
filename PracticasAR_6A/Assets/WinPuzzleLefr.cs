using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPuzzleLefr : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("PlayCapsule"))
        {
            Debug.Log("Ganaste");
            GameObject Victory = GameObject.Find("GANASTE");
            GameObject capsula = GameObject.Find("PlayCapsule");
            Destroy(capsula);
            Victory.SetActive(true);
        }
    }
}
