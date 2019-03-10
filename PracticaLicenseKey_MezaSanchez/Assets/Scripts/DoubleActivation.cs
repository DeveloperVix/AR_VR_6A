using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;

public class DoubleActivation : MonoBehaviour
{

    Rigidbody rb;
    public bool mainCheck;
    public GameObject otherButton;
    public GameObject button;
    public AudioSource win;

    // Start is called before the first frame update
    void Start()
    {
        mainCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (otherButton.activeSelf && button.activeSelf && mainCheck)
        {
            mainCheck = false;
            win.Play();
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            mainCheck = true;
            button.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            mainCheck = false;
            button.SetActive(false);
        }
    }
}
