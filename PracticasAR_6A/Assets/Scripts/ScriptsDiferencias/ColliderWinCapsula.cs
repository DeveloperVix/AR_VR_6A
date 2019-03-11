using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWinCapsula : MonoBehaviour
{
    public GameObject Ganaste;
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
        if (other.name.Equals("Capsule"))
        {
            Debug.Log("Ganaste");
            GameObject capsula = GameObject.Find("Capsule");
            Destroy(capsula);
            Ganaste.SetActive(true);
        }
    }
}
