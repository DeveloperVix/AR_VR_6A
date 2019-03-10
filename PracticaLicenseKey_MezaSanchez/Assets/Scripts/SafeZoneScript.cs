using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{

    Rigidbody rb;
    public GameObject door;
    public Transform spawnPosition;

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
        if(other.tag.Equals("Player") && !door.activeSelf)
        {
            Debug.Log("Ganaste tio... Recargando nivel");
            door.SetActive(true);
            other.transform.position = spawnPosition.position;
        }
        else if (other.tag.Equals("Player"))
        {
            Debug.Log("ENTRO A LA ZONA SEGURA!!!");
        }
    }
}
