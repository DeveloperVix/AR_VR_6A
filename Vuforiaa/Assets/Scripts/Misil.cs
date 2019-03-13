using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-700, 0, 0));
    }


    void Update()
    {
        if (transform.position.x <= -15 || transform.position.x >= 25)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag.Equals("Player"))
        {
            Destroy(col.gameObject);
            GameObject obj = GameObject.Find("GameControler");
        }
        
    }
}

