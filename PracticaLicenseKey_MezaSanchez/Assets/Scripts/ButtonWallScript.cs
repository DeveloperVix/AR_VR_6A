using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWallScript : MonoBehaviour
{

    Rigidbody rb;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Toco el boton!!!");
            door.SetActive(false); 
        }
    }
}
